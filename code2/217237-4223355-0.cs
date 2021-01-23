    using (DbConnection connection = db.CreateConnection())
    {
        connection.Open();
        DbTransaction transaction = connection.BeginTransaction();
    
        try
        {
            db.ExecuteNonQuery(transaction, sp1);
            db.ExecuteNonQuery(transaction, sp2);
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
