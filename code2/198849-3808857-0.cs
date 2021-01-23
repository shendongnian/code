    using MySql.Data.MySqlClient;
    using MySql.Data.Types;
    
    // snip 
        string sourceString = "Server=127.0.0.1;Uid=root;Pwd=password;Database=dbname;";
        string[] tables = { "Table1", "Table2"};
        using (MySqlConnection source = new MySqlConnection(sourceString))
        {
            source.Open();
            foreach (string table in tables)
            {
                using (MySqlCommand readCommand = new MySqlCommand("select * from " + table, source))
               {
                   using (MySqlDataReader reader = readCommand.ExecuteReader())
                   {
                        while (reader.Read())
                        {
                             // do work here
                        }
                   }
               }
           }
       }
