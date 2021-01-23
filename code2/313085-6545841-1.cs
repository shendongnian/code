    IEnumerable<Entity> entities;
    int rangeStartIndex = 0;
    int rangeLength = 1000;
    
    do
    {
        entities = dataContext.Entities
            .Skip(rangeStartIndex)
            .Take(rangeLength);
    
        Parallel.ForEach(
            entities,
            item =>
            {
                // Process a single entity in the list
            });
    
        using (var tran = new TransactionScope())
        {
            // Persist the entities in the database
            tran.Complete();
        }
    
        rangeStartIndex += rangeLength;
    
    } while (entities.Any());
