    class Program
        {
            private static string connString = @"User Id=User; Password=root; Data Source=SOURCE";
    
            private static List<string> forecast_types = new List<string> { "a", "b" };
            private static List<double> forecast_values = new List<double> { .1, .2 };
    
            static void Main(string[] args)
            {
                using (var con = new OracleConnection(connString))
                {
                    //string query = "BEGIN curves.sp_insert(:forecast_types, :forecast_values); END;";
    				string query = "curves.sp_insert";
    
                    try
                    {
                        con.Open();
    
                        using (OracleCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.StoredProcedure; // CommandType.Text; //you can change this to a stored procedure and not utilize the anonymous block
    						
    						cmd.ArrayBindCount = 2; //use ArrayBindCount
    						
                            cmd.BindByName = true;
    
                         cmd.Parameters.Add(new OracleParameter
                            {
                                ParameterName = ":forecast_types",
                                OracleDbType = OracleDbType.Varchar2,
                                Value = forecast_types.ToArray(),
                                Direction = ParameterDirection.Input,
                                //CollectionType = OracleCollectionType.PLSQLAssociativeArray //this is not needed
                            }
                        );
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = ":forecast_values",
                            OracleDbType = OracleDbType.Double,
                            Value = forecast_values.ToArray(),
                            Direction = ParameterDirection.Input,
                            //CollectionType = OracleCollectionType.PLSQLAssociativeArray  //this is not needed
                        }
                            );
    
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        System.Console.WriteLine(ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
