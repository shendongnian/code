    private IEnumerable<int> FilterIdsByClient(IEnumerable<int> entityIds) 
    { 
        // The variable entityIds points to whatever was passed in: A List, according to the edited question.
        entityIds =                                    //this is an assignment, changing the referent of entityIds
            MyObjectContext.CreateObjectSet<TEntity>() 
                .Where(x => x.ClientId == _clientId) 
                .Where(x => entityIds.Contains(x.Id))  //this lambda closes over the variable entityIds
                .Select(x => x.Id); 
        // The query now has a reference to the *variable* entityIds, not to the object that entityIds pointed to originally.
        // The value of entityIds has been changed; it now points to the query itself!
        // The query is therefore operating on itself; this causes the "cycle detected" message.
        // Because of delayed execution, the query is not executed until the next line of code:
        return entityIds.ToList();
    }
