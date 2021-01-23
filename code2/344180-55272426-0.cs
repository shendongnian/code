        public static IReadOnlyList<IProperty> GetPrimaryKeyProperties<T>(this DbContext dbContext)
        {
            return dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties;
        }
        //TODO Precompile expression so this doesn't happen everytime
        public static Expression<Func<T, bool>> FilterByPrimaryKeyPredicate<T>(this DbContext dbContext, object[] id)
        {
            var keyProperties = dbContext.GetPrimaryKeyProperties<T>();
            var parameter = Expression.Parameter(typeof(T), "e");
            var body = keyProperties
                // e => e.PK[i] == id[i]
                .Select((p, i) => Expression.Equal(
                    Expression.Property(parameter, p.Name),
                    Expression.Convert(
                        Expression.PropertyOrField(Expression.Constant(new { id = id[i] }), "id"),
                        p.ClrType)))
                .Aggregate(Expression.AndAlso);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
        public static Expression<Func<T, object[]>> GetPrimaryKeyExpression<T>(this DbContext context)
        {
            var keyProperties = context.GetPrimaryKeyProperties<T>();
            var parameter = Expression.Parameter(typeof(T), "e");
            var keyPropertyAccessExpression = keyProperties.Select((p, i) => Expression.Convert(Expression.Property(parameter, p.Name), typeof(object))).ToArray();
            var selectPrimaryKeyExpressionBody = Expression.NewArrayInit(typeof(object), keyPropertyAccessExpression);
            return Expression.Lambda<Func<T, object[]>>(selectPrimaryKeyExpressionBody, parameter);
        }
        public static IQueryable<TEntity> FilterByPrimaryKey<TEntity>(this DbSet<TEntity> dbSet, DbContext context, object[] id)
            where TEntity : class
        {
            return FilterByPrimaryKey(dbSet.AsQueryable(), context, id);
        }
        public static IQueryable<TEntity> FilterByPrimaryKey<TEntity>(this IQueryable<TEntity> queryable, DbContext context, object[] id)
            where TEntity : class
        {
            return queryable.Where(context.FilterByPrimaryKeyPredicate<TEntity>(id));
        }
