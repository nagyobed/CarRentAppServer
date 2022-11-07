using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        BasicHttpBinding binding = new BasicHttpBinding();
        
        public SqlConnection myCon;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void LoadSql()
        {
            binding.MaxReceivedMessageSize = 2147483647;
            String ConnectionString = "Data Source=DESKTOP-78DQV8P;Initial Catalog=II_Prot_1;Integrated Security=True";
            myCon = new SqlConnection();
            myCon.ConnectionString = @ConnectionString;
        }
        [WebMethod]
        public DataSet dsCreate(String cmd)
        {
            this.LoadSql();
            myCon.Open();
            DataSet dsUser = new DataSet();
            SqlDataAdapter daUser = new SqlDataAdapter(cmd, myCon);
            daUser.Fill(dsUser);
            myCon.Close();
            return dsUser;
        }
        [WebMethod]
        public void executeCmd(String cmdString)
        {
            this.LoadSql();
            myCon.Open();
            SqlCommand cmd = new SqlCommand(cmdString, myCon);
            cmd.ExecuteNonQuery();
            myCon.Close();
        }
        [WebMethod]
        public String listSort(Boolean ckBox2, Boolean ckBox8, Boolean ckBox9, Boolean ckBox10, Boolean ckBox3, Boolean ckBox4, Boolean ckBox5, Boolean ckBox6, Boolean ckBox7, String txt2, String cBox1, int value1, int value2)
        {
            Boolean validValue = false;
            String sortCmd = "";
            if (ckBox2)
            {
                sortCmd = sortCmd + "Car_list.available = 1";
                validValue = true;
            }

            if (ckBox8)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Car_list.Marca like '" + txt2 + "'";
                validValue = true;
            }

            if (ckBox9)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Car_specs.combustibil like '" + cBox1 + "'";
                validValue = true;
            }
            if (ckBox10)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Pretiuri.pret_zi > " + value1 + " and Pretiuri.pret_zi < " + value2;
                validValue = true;
            }
            if (ckBox3)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Car_specs.Hibrid = 1";
                validValue = true;
            }
            if (ckBox4)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Car_specs.System_navigation = 1";
                validValue = true;
            }
            if (ckBox5)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Car_specs.aer_cond = 1";
                validValue = true;
            }
            if (ckBox6)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Car_specs.Bluetooth = 1";
                validValue = true;
            }
            if (ckBox7)
            {
                if (validValue)
                {
                    sortCmd = sortCmd + " and ";
                }
                sortCmd = sortCmd + "Car_specs.USB_port = 1";
                validValue = true;
            }
            return sortCmd;
        }
    }
}
