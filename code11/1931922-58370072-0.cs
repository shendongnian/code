csharp
        public static async Task<ICollection<TEntity>> GetAllAsync<TEntity, TOrderBy>
            (
            Expression<Func<TEntity, TOrderBy>> orderBy,
            bool isDescendingOrder = false,
            Expression<Func<TEntity, TEntity>> projection = null,
            CancellationToken cancellationToken = default
            )
        {
            var query = _collection.AsQueryable();
            var sortedQuery = isDescendingOrder ?
                                query.OrderByDescending(orderBy) :
                                query.OrderBy(orderBy);
            if (projection != null)
            {
                query = sortedQuery.Select(projection);
            }
            return await query.ToListAsync(cancellationToken) as ICollection<TEntity>;
        }
test program: 
