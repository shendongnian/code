    using (var tx = session.BeginTransaction())
    {
        session.CreateSQLQuery("CREATE TEMP TABLE usedIds (id INT)").ExecuteUpdate();
        
        for (int index = 0; index < ids.Length; index++)
        {
            // TODO: batch this
            session.CreateSQLQuery("INSERT INTO usedIds VALUES (:p" + index + ")")
                .SetParameter("p" + index, id)
                .ExecuteUpdate();
        }
        
        session.CreateSQLQuery("CREATE INDEX usedIds_idx ON usedIds (id)").ExecuteUpdate();
        
        
        Batch batch;
        while((batch.List = session.CreateSQLQuery("SELECT id FROM tasks t WHERE 1 = (SELECT COUNT(*) FROM usedIds u WHERE u.id = t.id) LIMIT 10 OFFSET " + batch.Number).List<int>()).Count > 0)
    
        {
            var tasks = session.QueryOver<Task>()
                .Where(t => t.Id.IsIn(batch))
                .List();
            // Do something with the tasks
        }
        tx.Commit();
    }
