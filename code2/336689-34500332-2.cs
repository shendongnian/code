    using (SqlConnection connection = new SqlConnection("Connection String"))
                    {
                        SqlCommand command = new SqlCommand("select top 10 * from myschema.MyTable", connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReaderAsync().Result;  
                        DataTable schemaTable = reader.GetSchemaTable();
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            //Console.WriteLine(row["ColumnName"]);
                            foreach (DataColumn column in schemaTable.Columns)
                            {    
                                Console.WriteLine(string.Format("{0} = {1}", column.ColumnName, row[column.ColumnName]));                                   
                               
                            }
                            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<");
                        }
    }
