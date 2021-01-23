    String conxString = @"Data Source=Instance1;User ID=FOO;Password=BAR;";
    //in your main function
    if(!TryConnect(conxString))
    {
       Console.WriteLine("SQL Creditials failed.  Trying with windows credentials...");
       conxString = "new conn string";
       TryConnect(conxString);
    }
    ..............
    //new function outside of your main function
    private bool TryConnect(string connString)
    {
       using (SqlConnection sqlConx = new SqlConnection(conxString))
         {
             Try{
                   sqlConx.Open();
                   DataTable tblDatabases = sqlConx.GetSchema("Databases");
                   sqlConx.Close();
             }
             Catch(System.Data.SqlClient.SqlException e){
                    return false;
             }
             return true;    
          }
    }
