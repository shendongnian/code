    catch (GenericADOException ex)
    {
        txn.Rollback();
        var sql = ex.InnerException as SqlException;
        if (sql != null && sql.Number == 2601)
        {
            // Here's where to handle the unique constraint violation
        }
        ...
    }
