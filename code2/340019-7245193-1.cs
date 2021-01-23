    public IEnumerable<Data> GetData()
    {
        using (var transaction = Session.BeginTransaction();
        {
            IQuery q = CreateQuery(session);
    
            foreach (var result in q.Enumerable())
            {
                yield return ProjectResult(result);
            }
    
            // Commits the tnrasaction, so disposing it won't roll it back.
            session.Commit();
        }
    }
