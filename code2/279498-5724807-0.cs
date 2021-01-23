    private void testconnection()
    {
      string strConnection = ConfigurationManager.ConnectionStrings["DDP_Project.Properties.Settings.DDP_DatabaseConnectionString"].ConnectionString;                     
      using (var conn = new SqlCeConnection(string.Format("Data Source={0};Max Database Size=4091;Max Buffer Size = 1024;Default Lock Escalation =100;", strConnection)))
               {
                   conn.Open();
    
                      {
                        try
    
                       {
    
                         //your Stuff                    
    
                       }
                       catch (SqlCeException)
                       {
                           throw;
                       }
                       finally
                       {
                           if (conn.State == ConnectionState.Open) conn.Close();
                       }
                   }
               }}
