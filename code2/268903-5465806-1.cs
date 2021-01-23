    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class SubmissionPage : System.Web.UI.Page
    {
    
       
    
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
    
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            String thisQuery = "INSERT INTO Customer (Name, SIC_NAIC, Address, City, State, Zip) VALUES ('" + TextBox1.Text + "', '" + RadioButtonList1.SelectedItem.Text + "', '" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + DropDownList1.SelectedItem.Text + "', '" + TextBox4.Text + "')";
    
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
    
                using (SqlCommand command = new SqlCommand(thisQuery, sqlConn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
