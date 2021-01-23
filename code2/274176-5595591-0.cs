        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> source,
                                                         IEnumerable<WhereSpecifier> orClauses)
            where TEntity : class
        {
            if (!orClauses.Any()) return source.Where(t => false);
            Type type = typeof (TEntity);
            ParameterExpression parameter = null;
            Expression predicate = Expression.Constant(false, typeof (bool));
            ParameterExpression whereEnt = Expression.Parameter(type, "WhereEnt");
            foreach (WhereSpecifier orClause in orClauses)
            {
                Expression selector;
                if (orClause.Selector != null)
                {
                    selector = orClause.Selector;
                    parameter = orClause.Parameter;
                }
                else
                {
                    parameter = whereEnt;
                    Type selectorResultType;
                    selector = GenerateSelector<TEntity>(parameter, orClause.Column, out selectorResultType);
                }
                Expression clause = selector.CallMethod(orClause.Method, 
                    MakeConstant(selector.Type, orClause.Value), orClause.Modifiers);
                predicate = Expression.Or(predicate, clause);
            }
            var lambda = Expression.Lambda(predicate, whereEnt);
            var resultExp = Expression.Call(typeof (Queryable), "Where", new[] {type},
                source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<TEntity>(resultExp);
        }
