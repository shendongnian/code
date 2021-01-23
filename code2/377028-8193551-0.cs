         public DataTable SampleQuery(string tablename)
                {
                    DataTable dataTable;
            
                    string query = "SELECT * FROM " + tablename;
            
                    //Open connection
                    if (this.OpenConnection() == true)
                    {
                        adapter = new MySqlDataAdapter(query,connection);
            
                        dataTable =  new DataTable();
                        adapter.Fill(dataTable);
            
                        //close Connection
                        this.CloseConnection();
                        return dataTable;
                    }
                  return dataTable;
                }
