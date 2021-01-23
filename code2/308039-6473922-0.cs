                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
    
                    SqlCommand comm = new SqlCommand("Select top(1) * from " + TableName + " Where 1=0");
                    comm.CommandType = CommandType.Text;
                    comm.Connection = conn;
                    using (SqlDataReader reader = comm.ExecuteReader(CommandBehavior.KeyInfo))
                    {
                        DataTable dt = reader.GetSchemaTable();
                        foreach (DataRow row in dt.Rows)
                        {
                            //Create a column
                            DataObjects.Column column = new DataObjects.Column();
    
                            column.ColumnName = (string)row["ColumnName"];
                            column.ColumnOrdinal = (int)row["ColumnOrdinal"];
                            column.ColumnSize = (int)row["ColumnSize"];
                            column.IsIdentity = (bool)row["IsIdentity"];
                            column.IsUnique = (bool)row["IsUnique"];
    
                            //Get the C# type of data
                            object obj = row["DataType"];
                            Type runtimeType = obj.GetType();
                            System.Reflection.PropertyInfo propInfo = runtimeType.GetProperty("UnderlyingSystemType");
                            column.type = (Type)propInfo.GetValue(obj, null);
    
                            //Set a string so we can serialize properly later on
                            column.DataTypeFullName = column.type.FullName;
    
                            //I believe this is SQL Server Data Type
                            column.SQLServerDataTypeName = (string)row["DataTypeName"];
    
                            //Do something with the column
                        }
                    }
                }
