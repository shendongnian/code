c#
public async Task<TResult> GetSingleAsync<TResult, TNewEntity>(Expression<Func<TNewEntity, TResult>> selector = null)
where TNewEntity: TEntity, TResult
{
    IQueryable<TNewEntity> query = this._collection;
    if (selector == null) selector = entity => (TResult) entity;
    return await query.Select(selector).SingleOrDefaultAsync();
}
Here you see the ugly type constraint that I was talking about. You have to introduce a new type in order to enforce that your class constraint is of type `TResult`.
**Option 2:** Type check and cast.
c#
public async Task<TResult> GetSingleAsync<TResult>(Expression<Func<TEntity, TResult>> selector = null)
{
    IQueryable<TNewEntity> query = this._collection;
    // I would use pattern matching here if I could, but unfortunately it looks like
    // expression trees cannot have pattern matching so we have to box then cast.
    if (selector == null) selector = entity =>  entity is TResult ? (TResult)(object) entity : default(TResult);
    return await query.Select(selector).SingleOrDefaultAsync();
}
With this, it will attempt to cast the entity to the correct type but if it can't it will return the default for `TResult` which will be `null` if its a reference type. This will still incur the same problem you were having before, but, in the cases where the cast succeeds, it could be what you want.
**Option 3:** Overload the method.
c#
// New method with no selector. Notice the return type is now TEntity
public async Task<TEntity> GetSingleAsync(){
    return GetSingleAsync(x => x); // This now works because TResult is TEntity.
}
// Original method, but now it requires the selector
public async Task<TResult> GetSingleAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
{
    IQueryable<TNewEntity> query = this._collection;
    return await query.Select(selector).SingleOrDefaultAsync();
}
Personally, this seems like the option that you are wanting and the one that I would use.  It essentially has the same functionality as the default parameter but now requires that, if the selector is not provided, the query will return `TEntity`. However, I don't know all the constraints of your problem or if the default parameter is required. 
Also, there may be other options that aren't listed here but these are the best ones that I could come up with. 
**Note:** I tested to see if these would compile, but have not ran any of them.
