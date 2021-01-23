    private IEnumerable<int> FilterIdsByClient(IEnumerable<int> entityIds) 
    { 
        entityIds = 
            MyObjectContext.CreateObjectSet<TEntity>() 
                .Where(x => x.ClientId == _clientId) 
                .Where(x => entityIds.Contains(x.Id))  //the query closes over the variable entityIds
                .Select(x => x.Id); 
        // The query now has a reference to the variable entityIds, not to the object that entityIds pointed to originally.
        // The value of entityIds has been changed; it no longer points to that object, but to the query!
        // The query is therefore operating on itself; this causes the "cycle detected" message.
        // Because of delayed execution, the query is not executed until the next line of code:
        return entityIds.ToList();
    } 
