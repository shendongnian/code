c#
//This creates the query as IEnumerable<someAnonymousRuntimeObject> but doesn't execute it.
var query = dt.AsEnumerable()
    .Where(i => i.Field<int>("customerId") == 1)
    .Select(i => new { name = i.Field<string>("customerName") });
//This actually executes the query and stores the result in name
var name = query.FirstOrDefault().name;
