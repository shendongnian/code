    Cursor.Current = Cursors.WaitCursor;
                                sqlConnection.Open();
                                System.Data.DataTable dataTable = sqlConnection.GetSchema("Databases");
        
                                foreach (System.Data.DataRow row in dataTable.Rows)
                                {
                                    using (var tablesConnection = new System.Data.SqlClient.SqlConnection())
                                    {
                                        var dbName = row[0] as string;
                                        try
                                        {
                                            sqlConnection.ChangeDatabase(dbName);
                                        }
                                        catch (Exception)
                                        {
                                            continue;
                                        }
        
                                        var tables = sqlConnection.GetSchema("Tables");
                                }
