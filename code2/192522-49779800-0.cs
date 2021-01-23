            public static IQueryable<TEntity> OfTypes<TEntity>(this DbSet<TEntity> query, IEnumerable<Type> types )  where TEntity : class
                {
                        if( types.Count() == 0 ) return query;
                        var lambda = GetOfOnlyTypesPredicate( typeof(TEntity), types.ToArray() );
                        return query.OfType<TEntity>().Where( lambda as Expression<Func<TEntity,bool>>);
                }
                
                public static LambdaExpression GetOfOnlyTypesPredicate( Type baseType, Type[] allowed )
                {
                        ParameterExpression param = Expression.Parameter( baseType, "typeonlyParam" );
                        Expression merged = Expression.TypeIs( param, allowed[0] );
                        for( int i = 1; i < allowed.Length; i++ )
                                merged = Expression.OrElse( merged, Expression.TypeIs( param, allowed[i] ));
                        return Expression.Lambda( merged, param );
