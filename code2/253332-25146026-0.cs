    public static async Task Update<T>(this DbSet<T> objectContext, Action<T> updateStatement, Expression<Func<T, bool>> where) where T : class
        {
            var items = objectContext.AsQueryable();
            // filter with the Expression if exist
            if (where != null)
                items = items.Where(where);
            // perform the Action on each item
            await items.ForEachAsync(updateStatement);
        }
