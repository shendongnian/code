 c#
    private Task<int> logObj(Audit obj)
    {
        using (var dbContext = new MyDbContext(new PjSqlConnectionStringBuilder()))
        {
            dbContext.Audits.Add(obj);
            return dbContext.SaveChangesAsync();
        }
    }
In particular, note that you're disposing a context while an operation is in flow. What you *need* is to await the pending operation:
 c#
    private async Task<int> logObj(Audit obj)
    {
        using (var dbContext = new MyDbContext(new PjSqlConnectionStringBuilder()))
        {
            dbContext.Audits.Add(obj);
            return await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
Adding the `await` here ensures that we don't dispose the `dbContext` until *after* the save has actually reported completion. The `ConfigureAwait` is largely optional; there's no *need* for this code to jump back to the sync-context, so it might as well not bother.
Note that you *do not* need to do this in `LogRequest` / `LogResponse`; they're fine as-written (although I'd probably add the `Async` suffix onto all 3 methods here). However, your calling code probably *should* `await`:
 c#
var lr1 = await ar.LogRequest(tr.TransactionId, T.ToString());
and since we're back at the app-tier here, we should let sync-context have a say in what happens (i.e. don't add `ConfigureAwait(false)` here)
