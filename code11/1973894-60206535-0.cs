    using (var ts = CreateTransactionScope(TimeSpan.FromSeconds(mySecondsVar)))
    { 
        using (System.Data.Common.DbConnection connection = o_DB.CreateConnection())
        {
            using (IDbTransaction tran = connection.BeginTransaction()) {
            try 
            {
                // your code
            }  
            catch {
                tran.Rollback();
            }
        }
    }
        ts.Complete();
    }
