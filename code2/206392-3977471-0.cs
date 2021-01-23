    static public DataTable ExecuteOleDataTable(string sql, string oledbconnectionstring)
       {
           using (OleDbCommand command = new OleDbCommand())
           {
               command.CommandType = CommandType.Text;
               OleDbConnection oledbconnection = new OleDbConnection(oledbconnectionstring);
               command.Connection = new OleDbConnection(oledbconnectionstring); ;
               command.CommandText = sql;
               
               if (oledbconnection.State == System.Data.ConnectionState.Open)
                   oledbconnection.Close();
               oledbconnection.Open();
               OleDbDataAdapter sda = new OleDbDataAdapter(command);
               DataTable datatable = new DataTable();
               sda.Fill(datatable);
               oledbconnection.Close();
               return datatable;
           }
       }
