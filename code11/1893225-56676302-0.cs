C#
public async Task<IEnumerable<UserDetail>> GetUserDetailsByCode(string code)
{
  using (var db = databaseFactory.Create())
  {
    return await db.UserDetails.GetByCode(code);
  }
}   
`IEnumerable<T>` is an enumerable, which are generally lazy-evaluated. In the meantime, the `Task<T>` is considered complete once the enumerable is *defined* (not when it is completed). And the context is disposed once that enumerable is *defined*. You would have the same problem if the code was synchronous.
The fix is to "reify" (evaluate) the enumerable before the context is disposed:
C#
public async Task<IReadOnlyCollection<UserDetail>> GetUserDetailsByCode(string code)
{
  using (var db = databaseFactory.Create())
  {
    return await db.UserDetails.GetByCode(code).ToList();
  }
}   
