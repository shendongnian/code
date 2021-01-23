    try
    {
        using (SqlCeConnection oConn = new SqlCeConnection(ConnectionString))
        {
            oConn.Open();
            using (SqlCeCommand command = oConn.CreateCommand())
            {
                using (SqlCeTransaction transaction = oConn.BeginTransaction())
                {
                   command.Transaction = transaction;
                   //delete from multiple tables using ADO.NET using command
                   transaction.Commit();
                }
            }
           
        }
    }
    catch
    {
       //error handling
    }
