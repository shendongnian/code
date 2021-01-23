    IEnumerable<Entity> results = Enumerable.Empty<Entity>();
    
    foreach (var node in selectedNodes)
    {
        results = results.Concat(Session.Query<Entity>().Where(...).Future<Entity>());
    }
    
    Show(results);
