using (var context = new MyContext())
using (var transaction = context.Database.BeginTransaction(IsolationLevel.Serializable)) {
        var saved = context.Table.FirstOrDefault(x => x.field1 == val1 && x.field2 == val2);
        if (saved != null)
        {
            //edits saved
        }
        else
        {
            context.Table.Add(new Table
            {
                field1 = val1,
                field2 = val2
            });
        }
        await context.SaveChangesAsync();
        transaction.Commit()
        return Json(true);
}
I use most isolated level here to lockdown the table and prevent race conditions in reading. This approach has performance implications and if retry is acceptable you can still follow this approach. There is a great framework [Polly.NET](https://github.com/App-vNext/Polly) which could be very handy for you:
await Policy.Handle<DbUpdateException>()
            .RetryAsync(5)
            .ExecuteAsync(() => ...);
I'd not recommend to use any in-process locks on your DbContext (or anything else) because that limits you to have a single process running with this logic what is not the case when you need high availability.
