qSQL = "INSERT INTO " + tableName + " EXEC [LINKEDSERVER\\LINKED].[Data_Base_Name]." + spName;
using (SqlConnection _connection = new SqlConnection(connectionString))
{
            try
            {
                    command = new SqlCommand();
                    command.Connection = _connection;
                    command.Connection.Open();
                    command.CommandText = _qSQL;
                    command.CommandTimeout = 300; //Because it takes long
                    SqlTransaction transaction;
                    transaction = connection.BeginTransaction();
                    try
                    {
                        command.Transaction = _transaction;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        Debug.WriteLine("Done");
                    }
                    catch (SqlException e)
                    {
                        Debug.WriteLine("Exception [{0}:{1}]", e.Number, e.Message);
                        transaction.Rollback();
                    }
		    //close connection
                    command.Connection.Close();
                }
                catch (SqlException e)
                {
                    command.Connection.Close();
                    Debug.WriteLine("exception error number: " + e.Number + ": " + e.Message);
                }
            }
}
If you have any suggestions to improve this let me know.
