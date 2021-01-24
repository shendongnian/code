    string cs = @"Data Source=datasource;Initial Catalog=databasename;User ID=user;Password=password";
     
    
        DataTable table = GetDataTable(cs, "Table1");
        using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                        {
                           conn.CreateTable<Table1>();
                           if (conn.Query<Table1>("select * from Table1").Count() <= 0)
                              {
                                  foreach(DataRow row in table.Rows) 
        
                                  {
                                    //Access values of each row column      row["columnName"]
                                    // insert the list object
                                  }
                              }
                        }
