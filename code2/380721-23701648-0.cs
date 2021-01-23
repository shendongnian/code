    private static void CheckIfOracleTableExists()
    {
     try
       {
           string connectionString = ConfigurationManager.ConnectionStrings["dbConnectString"].ConnectionString;
           if (connectionString == null) throw new Exception();
         
           using (OracleConnection orclConn = new OracleConnection(connectionString))
           using (OracleCommand orclCmd = new OracleCommand())
               {
               orclConn.Open();
               orclCmd.Connection = orclConn;
               string commandText = String.Format("SELECT COUNT(*) FROM " + DbTestName);
               orclCmd.CommandText = commandText;
               orclCmd.CommandType = CommandType.Text;
               orclCmd.CommandTimeout = Convert.ToInt32(DbTimeout);
          
               try
               {
                   orclCmd.ExecuteScalar();
                   {
                       if (orclCmd.RowSize == 0) return;
                       TableExists = true;
                       orclConn.Close();
                       orclConn.Dispose();
                       orclCmd.Dispose();
                   }
                }
                catch (OracleException oex)
                {
                   if (oex.ToString().Contains("table or view does not exist"))
                      {
                         Console.WriteLine("\r\n\tTable not found.");
                      }
                      TableExists = false;
                }
                catch (OracleException oex)
                {
                    Console.WriteLine("{0}", oex);
                    TableExists = false;
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("Object reference not set to an instance of an object"))
                
                    Console.WriteLine("\r\n\t Invalid Connection String.");
                }
                TableExists = false;
               }
        }    
    }//// / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / / /
