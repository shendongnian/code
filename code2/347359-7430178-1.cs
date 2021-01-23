    public TaskMap()
    {
    
        Map(x => x.IsUsedCount).Formula("SELECT (SELECT COUNT(*) FROM usedIds u WHERE u.Id = Id)").LazyLoad();
    }
    var tasks = session.QueryOver<Task>()
        .Where(t => t.IsUsedCount == 0)
        .List();
