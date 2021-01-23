     Event randomEvent = (Event)ActiveRecordMediator<Event>.Execute(
        (session, instance) =>
            {
    
                var query = "SELECT top 1 * from [Event] ORDER BY NEWID()";
    
                ISQLQuery qry = session.CreateSQLQuery(query).AddEntity(typeof(Event));
                Event rand = qry.List<Event>().First();
    
                return rand;
            },new Event());
