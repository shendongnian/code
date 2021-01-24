C#
public async Task<TOut> ExecuteInTransactionAsync<TOut>(Func<Task<TOut>> function)
{
    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
    {
        var result = await (function()).ConfigureAwait(false);
        scope.Complete();
        return result;
    }
}
This signature would mean you'd need to capture parameters rather than pass them:
C#
public async Task<dynamic> SaveEntireEntity(EntityDTO entityDTO)
{
  return await _transactionProvider.ExecuteInTransactionAsync(
     async () => await SaveInTransaction(
         new { Name = entityDTO.Name, Address = entityDTO.Address, Age = entityDTO.Age }));
}
Once you're using the strongly-typed `Func<Task<T>>` instead of `Delegate` in your method signature, you can create an overload for `ExecuteInTransactionAsync` as such:
C#
public async Task ExecuteInTransactionAsync(Func<Task> function)
{
    using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
    {
        await (function()).ConfigureAwait(false);
        scope.Complete();
    }
}
which can be used as such:
C#
public async Task UpdateEntireEntity(UpdateEntityDTO entityDTO)
{
  await _transactionProvider.ExecuteInTransactionAsync(
    async () => await UpdateInTransaction(
        new { Name = entityDTO.Name, Address = entityDTO.Address, Age = entityDTO.Age }));
}
private async Task UpdateInTransaction(dynamic dto)
{
  await UpdateName(dto.Name);
  await UpdateAddress(dto.Address);
  await UpdateAge(dto.Age);
}
