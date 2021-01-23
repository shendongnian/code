       string connectionString = "database=test;server=localhost;uid=" + usr.Text + ";pwd=" + pwd.Text;
       using (SqlConnection conn = new SqlConnection(connectionString))
       {
         try
         {
           conn.Open();
         }
         catch (SqlException ex)
         {
           switch (ex.Number) 
           { 
             case 4060: // Invalid Database 
              ....
              break;
             case 18456: // Login Failed 
              ....
              break;
             default:
              ....
              break;
           } 
         }
       }
   
