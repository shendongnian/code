    Expression<Func<TEntity, bool>> result = Expression.Lambda<Func<TEntity, bool>>(
                Expression.GreaterThan(
                    Expression.Call( CountMethod( elementType ),
                                    Expression.Call( WhereMethod( elementType ),
                                                    theCollectionWeAreSearching,
                                                    filter ) ),
                    Expression.Constant( 0 ) ), param );
