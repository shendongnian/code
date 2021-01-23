    public static IQueryable<GRes<TKey>> CountIn<TKey, TValue>(this IQueryable<IGrouping<TKey, TValue>> source, IEnumerable<string> values, Expression<Func<TValue,string>> selector)
        {
            ParameterExpression xExpr = selector.Parameters[0];
            Expression propExpr = selector.Body;
            MethodInfo mi = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
            Expression res = Expression.Constant(0);            
            foreach (string term in values)
            {
                Expression value = Expression.Constant(term);
                MethodCallExpression methodEpr = Expression.Call(propExpr, mi,value);
                Expression tx = Expression.Condition(methodEpr, Expression.Constant(1), Expression.Constant(0));
                res = Expression.Add(res, tx);
            }
            var r0 = Expression.Lambda<Func<pp_Disease, int>>(res, xExpr);
            
            Type groupingType = typeof(IGrouping<TKey, TValue>);
            ParameterExpression selPar = Expression.Parameter(groupingType, "i");
            MethodInfo mi1 = typeof(Enumerable).GetMethods()
                .FirstOrDefault(m => m.Name == "Sum" 
                    && m.ReturnParameter.ParameterType == typeof(int)
                    && m.GetParameters().Count() == 2)
                .MakeGenericMethod(typeof(pp_Disease));
            Expression r1 = Expression.MemberInit(Expression.New(typeof(GRes<TKey>))
                , Expression.Bind(typeof(GRes<TKey>).GetMember("Count")[0], Expression.Call(mi1, selPar, r0))
                , Expression.Bind(typeof(GRes<TKey>).GetMember("Key")[0], Expression.Property(selPar, "Key")));
            return source.Select(Expression.Lambda<Func<IGrouping<TKey, TValue>, GRes<TKey>>>(r1, selPar));
        }
