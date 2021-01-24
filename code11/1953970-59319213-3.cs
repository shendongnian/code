var actives= ctx.Subscriptions
                .Where(sub=>sub.Date <= reportDate )
                .GroupBy(sub=>sub.CellNumber)
                .Where(grp=>grp.Max(sub=>sub.ActionId)<2)  // Results in a HAVING clause
                .Distinct()
                .Count();
    
Adding the rest of the criteria :
var query = ctx.Subscriptions
                .Where(sub=>sub.Date <= reportDate && sub.ServiceToken == serviceToken);
if(isPrepaid.HasValue)
{
    query = query.Where(sub => sub.IsPrePaid==isPrepaid);
}
var actives= query.GroupBy(sub=>sub.CellNumber)
                  .Where(grp=>grp.Max(sub=>sub.ActionId)<2)
                  .Distinct()
                  .Count();
**SQL Server 2016 temporal tables**
If we are lucky enough to use SQL Server 2016 or later, we can convert `Subscriptions` into a temporal table and simply count the subscriptions with a specific state at a certain point in time. We could just use :
    SELECT COUNT(DISTINCT CellPhoneNumber)
    FROM Subscriptions  FOR SYSTEM_TIME AS OF @someTime
    WHERE ActionID<2
EF Core doesn't support temporal tables directly, so we need to use [FromSqlRaw](https://docs.microsoft.com/en-us/ef/core/querying/raw-sql) for that part of the query :
var query = ctx.Subscriptions
                .FromSqlRaw("select * from Subscriptions FOR SYSTEM_TIME AS OF {0}",
                            reportDate)
                .Where(sub=>sub.Date <= reportDate && sub.ServiceToken == serviceToken);
if(isPrepaid.HasValue)
{
    query = query.Where(sub => sub.IsPrePaid==isPrepaid);
}
var actives= query.Distinct()
                  .Count();
There's no grouping involved in that query. It doesn't depends on the actual number or order of the Action values, nor is it confused by multiple records per subscription.
