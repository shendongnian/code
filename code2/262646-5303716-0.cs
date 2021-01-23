    using System.Data.Odbc;
    partial class login : System.Web.UI.Page
    {
    
        protected void  // ERROR: Handles clauses are not supported in C#
        Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            using(OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=localhost;Database=mydb; User=root;Password=;"));
            using(OdbcCommand cmd = new OdbcCommand("Select * from login where username=? and password=?", cn))
            {
               cn.Open();
    
               //Add parameters to get the username and password  
    
               cmd.Parameters.Add("@username", OdbcType.VarChar);
               cmd.Parameters("@username").Value = this.Login1.UserName;
    
               cmd.Parameters.Add("@password", OdbcType.VarChar);
               cmd.Parameters("@password").Value = this.Login1.Password;
    
               // Initialise a reader to read the rows from the login table.  
               // If row exists, the login is successful  
    
               using(OdbcDataReader dr = cmd.ExecuteReader)
               {
                 if (dr.HasRows) {
                     e.Authenticated = true;
                   // Event Authenticate is true  
                 }
              }
    
        }
    }
