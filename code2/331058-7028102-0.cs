      public DataTable DataReader(string query)
        {
            DataTable mysqlDataTable = new DataTable();
            try
            {
                ConnectToMysql();// Add Mysql Connection Here. 
                MySqlDataAdapter readerAdapter = new MySqlDataAdapter(query, MysqlDBConnection);//MySqlConnection MysqlDBConnection;
                readerAdapter.Fill(mysqlDataTable);
                readerAdapter.Dispose();
                MysqlDBConnection.Close();
                MysqlDBConnection.Dispose();
                return mysqlDataTable;
            }
            catch
            {
                throw;
            }
        }
