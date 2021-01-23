    private List<Customer> GetCustomers( )
    {
        string sqlStatement = "SELECT ID, Name FROM Customer";                
        using (var conn = new MySqlConnection(connString))
        {
            using (var cmd = new MySqlDataCommand(conn))
            {
               //get a reader and do something
               using (var reader = new MySqlDataReader(sqlStatement))
               { 
                   ...
               }
            }
        }
    }
   
