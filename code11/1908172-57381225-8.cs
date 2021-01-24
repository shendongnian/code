    public static class ExpressionFactory {
            public static Expression<Func<dynamic, bool>> PropertyGreaterThanPredicate(string propertyName, int value){
                var constant = Expression.Constant(value);
    
                var parameter = Expression.Parameter(typeof(object), "m");
    
                // Creating binder to access class member
                var binder = Binder.GetMember(CSharpBinderFlags.None, propertyName, typeof(Program), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
    
                // Dynamic operation on the binder
                var dynamic = Expression.Dynamic(binder, typeof(object), parameter);
    
                // Converting result to same type as value to compare
                var converted = Expression.Convert(dynamic, constant.Value.GetType());
    
                var predicate = Expression.GreaterThan(converted, constant);
    
                var lambda = Expression.Lambda<Func<dynamic, bool>>(predicate, parameter);
    
                return lambda;
            }
    
            public static Expression<Func<dynamic, bool>> IndexLessThanPredicate(string indexName, int value) {
                var constant = Expression.Constant(value);
    
                var parameter = Expression.Parameter(typeof(object), "m");
    
                // Creating binder to access indexer
                var binder = Binder.GetIndex(CSharpBinderFlags.None, typeof(Program), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
    
                // Dynamic operation on the binder
                var dynamic = Expression.Dynamic(binder, typeof(object), parameter, Expression.Constant(indexName));
    
                // Converting result to same type as value to compare
                var converted = Expression.Convert(dynamic, constant.Value.GetType());
    
                var predicate = Expression.LessThan(converted, constant);
    
                var lambda = Expression.Lambda<Func<dynamic, bool>>(predicate, parameter);
    
                return lambda;
            }
        }
