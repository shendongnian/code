    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    public partial class _Default : System.Web.UI.Page
    {
      SqlConnection conn;
      SqlCommand cmd;
      string connectionString = ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString;
    
      protected void Button1_Click(object sender, EventArgs e)
      {
        using (conn = new SqlConnection(connectionString))
        {
          if (!(conn.State == ConnectionState.Open))
          {
            conn.Open();
          }
          string sql = "CREATE TABLE mySchoolRecord(StudentId INTEGER CONSTRAINT PkeyMyId PRIMARY KEY, Name CHAR(50)," + "Address CHAR(255)," + "Contact INTEGER));";
          cmd = new SqlCommand(sql, conn);
          cmd.ExecuteNonQuery();
    
          sql = "INSERT INTO mySchoolRecord (StudentId, Name,Address,Contact) VALUES (1, 'Mr. Manish', " + " 'Sector-12,Noida', 2447658  );";
          cmd = new SqlCommand(sql, conn);
          cmd.ExecuteNonQuery();
    
          sql = "INSERT INTO mySchoolRecord (StudentId, Name,Address,Contact) VALUES (2, 'Mr. Ravi', " + " 'New Delhi', 2584076521   );";
          cmd = new SqlCommand(sql, conn);
          cmd.ExecuteNonQuery();
    
          sql = "INSERT INTO mySchoolRecord (StudentId, Name,Address,Contact) VALUES (3, 'Mr. Peter', " + " 'United States', 25684124  );";
          cmd = new SqlCommand(sql, conn);
          cmd.ExecuteNonQuery();
    
          if (conn.State == ConnectionState.Open)
          {
            conn.Close();
          }
        }
      }
    }
