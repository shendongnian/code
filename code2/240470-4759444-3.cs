    class Program
        {
            private static string connString = @"User Id=User; Password=root; Data Source=SOURCE";
    
            private static List<string> forecast_types = new List<string> { "a", "b" };
            private static List<double> forecast_values = new List<double> { .1, .2 };
    
            static void Main(string[] args)
            {
                using (var con = new OracleConnection(connString))
                {
                    string query = "curves.sp_insert";
    
                    try
                    {
                        con.Open();
    
                        using (OracleCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.BindByName = true;
    
                            cmd.Parameters.Add(new OracleParameter
                                {
                                    ParameterName = "param1",
                                    OracleDbType = OracleDbType.Varchar2,
                                    Value = forecast_types.ToArray(),
                                    Direction = ParameterDirection.Input,
                                    CollectionType = OracleCollectionType.PLSQLAssociativeArray,
    								Size = 2
                                }
                            );
                            cmd.Parameters.Add(new OracleParameter
                            {
                                ParameterName = "param2",
                                OracleDbType = OracleDbType.Double,
                                Value = forecast_values.ToArray(),
                                Direction = ParameterDirection.Input,
                                CollectionType = OracleCollectionType.PLSQLAssociativeArray,
    							Size = 2							
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
