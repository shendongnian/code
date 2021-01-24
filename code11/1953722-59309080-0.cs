public async Task<bool> HasUniqueNameAsync(Entity entity, string propName, CancellationToken cancellationToken = default(CancellationToken))
{
    return !await _dbContext.Entities.AnyAsync(x => x.PropName == propName && x.Id != entity.Id);
}
then you can move the negation into the function by doing this:
public Task<bool> HasUniqueNameAsync(Entity entity, string propName, CancellationToken cancellationToken = default(CancellationToken))
{
    return _dbContext.Entities.AllAsync(x => !(x.PropName == propName && x.Id != entity.Id));
}
Alternatively, you can use continuations to tack operations onto a task to be executed when it finishes:
public async Task<bool> HasUniqueNameAsync(Entity entity, string propName, CancellationToken cancellationToken = default(CancellationToken))
{
    return !await _dbContext.Entities
        .AnyAsync(x => x.PropName == propName && x.Id != entity.Id)
        .ContinueWith(x => !x.Result);
}
Finally, I note that you're not using that `CancellationToken` in your code. You should pass that into `AnyAsync()` (and also into `ContinueWith()` if you choose to go that route).
