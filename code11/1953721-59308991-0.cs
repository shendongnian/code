    public Task<bool> HasUniqueNameAsync(Entity entity, string propName, CancellationToken cancellationToken = default(CancellationToken))
    {
        return _dbContext.Entities
            .AnyAsync(x => x.PropName == propName && x.Id != entity.Id))
            .ContinueWith(continuation => !continuation.Result, cancellationToken );
    }
