    public IEnumerable<Data> GetData()
    {
        var transaction = Session.BeginTransaction();
        bool rollback = true;
        try 
        {
            IQuery q = CreateQuery(session);
    
            foreach (var result in q.Enumerable())
            {
                yield return ProjectResult(result);
            }
    
            rollback = false;
            session.Commit();
        }
        finally
        {
            if (rollback)
            {
                transaction.Rollback();
            }
            transaction.Dispose();
        }
    }
