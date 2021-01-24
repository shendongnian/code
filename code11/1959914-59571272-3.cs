    public void Execute(string TransactionName, string[] Queries, params SqlParameter[][] Parameters)
    {
        using (var Connection = new SqlConnection(Configuration.ConnectionString))
        using (var Transaction = new SqlTransaction(TransactionName))
        {
            connection.Transaction = Transaction;
            Connection.Open();
            try 
            {
                for (int i = 0; i < Queries.Length; i++)
                {
                    using (var Command = new SqlCommand(Queries[i], Connection))
                    {
                        command.Transaction = Transaction;
                        if (Parameters[i].Length > 0)
                        {
                            Command.Parameters.Clear();
                            Command.Parameters.AddRange(Parameters);
                        }                
                        Command.ExecuteNonQuery();
                    }
                }
                Transaction.Commit();
            }
            catch(Exception ex)
            {
                Transaction.Rollback();
                throw; //I'm assuming you're handling exceptions at a higher level in the code
            }
        }
    }
