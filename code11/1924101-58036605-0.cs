c#
public virtual async Task<OperationResult> DeleteAsync(Expression<Func<TEntity, bool>> expression) {
    _DbContext.Set<TEntity>().RemoveRange(somethinghere);
    try {
        //commit the changes
        var result = await _DbContext.SaveChangesAsync();
        //result will be an int (the number of records changed), not a Task
        //if we got this far, we succeeded
        return new OperationResult()
        {
            Message = "",
            ReturnObject = null,
            Status = OperationStatus.Deleted,
            Succeeded = true
        };
    } catch (Exception e) {
        
        return new OperationResult()
        {
            Message = "", //you can use e.Message here if you want
            ReturnObject = null,
            Status = OperationStatus.UnknownError,
            Succeeded = false
        };
    }
}
Note that you could just put:
    await _DbContext.SaveChangesAsync();
If you don't intend on using `result`.
