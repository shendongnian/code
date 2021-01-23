    private IEnumerable<int> FilterIdsByClient(IEnumerable<int> entityIds)
    {
        var query =
            MyObjectContext.CreateObjectSet<TEntity>()
                .Where(x => x.ClientId == _clientId)
                .Where(x => entityIds.Contains(x.Id))
                .Select(x => x.Id);
    
        return query.ToList();
    }
