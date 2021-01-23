            using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data;
    using System.Data.SqlClient;
    
    
    
    namespace WebApplication2
    {   public class SqlConnectionDemo
        {
    
        SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
    
            
    
        public partial class WebForm2 : System.Web.UI.Page
        {
      protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void Button1_Click(object sender, EventArgs e)`enter code here`
            {
          SqlDataReader rdr = null;
          try {
    
              conn.Open();
              SqlCommand cmd = new SqlCommand("select * from Customers", conn);
              rdr = cmd.ExecuteReader();
    
    
              while (rdr.Read()) {
                  Console.WriteLine(rdr[0]);
              }
          } finally {
              // close the reader
              if (rdr != null) {
                  rdr.Close();
              }
    
              // 5. Close the connection
              if (conn != null) {
                  conn.Close();
              }
          }
      }
            }
        }
