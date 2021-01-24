    app.Use(async (context,next) =>
    {                
        if (context.Request.Query.TryGetValue("fbclid", out StringValues query))
        {
            var items = context.Request.Query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();
            // At this point you can remove items if you want
            items.RemoveAll(x => x.Key == "fbclid"); // Remove all values for key
            var qb = new QueryBuilder(items);
            context.Request.QueryString = qb.ToQueryString();
        }
        await next.Invoke();
    });
