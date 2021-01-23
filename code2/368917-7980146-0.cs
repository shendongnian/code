        using (SqlCeTransaction transaction = oConn.BeginTransaction())
        {
            try
            {
              //delete from multiple tables using ADO.NET
              transaction.Commit();
            }
            catch
            {
               transaction.Rollback();
               throw;
            }
        }
