    using (var connection = new SqlConnection(Configuration.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    SqlTransaction transaction;
                    connection.Open();
                    transaction = connection.BeginTransaction("Transaction");
                    command.Connection = connection;
                    command.Transaction = transaction;
                    try
                    {
                        if (Parameters.Length > 0)
                        {
                            command.Parameters.Clear();
                            command.Parameters.AddRange(Parameters);
                        }
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception ex2)
                        {
                           //trace
                        }
                    }
                   
                }
