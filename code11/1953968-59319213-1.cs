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
