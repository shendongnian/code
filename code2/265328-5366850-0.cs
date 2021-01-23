    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Xml.Linq;
    //using PractiseWeb.DataSet1TableAdapters;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data.Odbc;
    using ADOX;
    using ADODB;
    
    public partial class _Default : System.Web.UI.Page 
    {
          SqlConnection conn;
          OdbcCommand cmd;
        string connectionString = ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try 
    {
    
       conn = new SqlConnection(connectionString);
      if (!(conn.State == ConnectionState.Open)) 
        { 
            conn.Open(); 
        } 
        string sql = "CREATE TABLE mySchoolRecord(StudentId INTEGER CONSTRAINT PkeyMyId PRIMARY KEY,"
        + "Name CHAR(50)," + "Address CHAR(255)," + "Contact INTEGER));"; 
        cmd = new SqlCommand(sql,conn);// in this line above two errors occurred
        cmd.ExecuteNonQuery(); 
    
        sql = "INSERT INTO mySchoolRecord (StudentId, Name,Address,Contact) VALUES (1, 'Mr. Manish', " + " 'Sector-12,Noida', 2447658  );";
        cmd = new SqlCommand(sql,conn);// in this line above two errors occurred
        cmd.ExecuteNonQuery(); 
    
        sql = "INSERT INTO mySchoolRecord (StudentId, Name,Address,Contact) VALUES (2, 'Mr. Ravi', " + " 'New Delhi', 2584076521   );"; 
        cmd = new SqlCommand(sql,conn);// in this line above two errors occurred
        cmd.ExecuteNonQuery();
    
        sql = "INSERT INTO mySchoolRecord (StudentId, Name,Address,Contact) VALUES (3, 'Mr. Peter', " + " 'United States', 25684124  );"; 
        cmd = new SqlCommand(sql,conn);// in this line above two errors occurred
        cmd.ExecuteNonQuery(); 
    
    
        if (conn.State == ConnectionState.Open) 
        { 
            conn.Close(); 
        } 
    
    } 
    catch (OdbcException ex) 
    { 
       Console.WriteLine(ex); 
    } 
    
        }
    }
