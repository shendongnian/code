    public static class MenuItemTree {
        public static MethodInfo GetGenericMethod(this Type type, string name, Type[] generic_type_args, Type[] param_types) {
            foreach (MethodInfo m in type.GetMethods())
                if (m.Name == name) {
                    var pa = m.GetParameters();
                    if (pa.Length == param_types.Length) {
                        var c = m.MakeGenericMethod(generic_type_args);
                        if (c.GetParameters().Select(p => p.ParameterType).SequenceEqual(param_types))
                            return c;
                    }
                }
            return null;
        }
    
        static MethodInfo GetGroupByMethodStatically<TElement, TKey>()
            => typeof(Enumerable).GetGenericMethod("GroupBy", new[] { typeof(TElement), typeof(TKey) }, new[] { typeof(IEnumerable<TElement>), typeof(Func<TElement, TKey>) });
    
        static MethodInfo GetEnumerableMethod(string methodName, Type TTElement, Type TTKey) {
            var TIE = typeof(IEnumerable<>).MakeGenericType(TTElement);
            var TF = typeof(Func<,>).MakeGenericType(TTElement, TTKey);
            return typeof(Enumerable).GetGenericMethod(methodName, new[] { TTElement, TTKey }, new[] { TIE, TF });
        }
    
        static MethodInfo GetEnumerableMethod(string methodName, Type TTElement) {
            var TIE = typeof(IEnumerable<>).MakeGenericType(TTElement);
            return typeof(Enumerable).GetGenericMethod(methodName, new[] { TTElement }, new[] { TIE });
        }
    
        public static List<MenuItem> GroupBySelector<TElement>(IEnumerable<TElement> source, IList<string> columnNames, int entry = 0) {
            if (source == null) throw new ArgumentNullException(nameof(source));
    
            string columnName = columnNames[entry];
    
            if (columnName == null) throw new ArgumentNullException(nameof(columnName));
            if (columnName.Length == 0) throw new ArgumentException(nameof(columnName));
    
            int nextEntry = entry + 1;
    
            var TTElement = typeof(TElement);
            var TIETElement = typeof(IEnumerable<TElement>);
    
            var keyParm = Expression.Parameter(TTElement);
            var prop = Expression.Property(keyParm, columnName);
    
            var parm = Expression.Parameter(TIETElement, "p");
            var gbmi = GetEnumerableMethod("GroupBy", TTElement, prop.Type);
            var gbExpr = Expression.Lambda(prop, keyParm);
            var body = Expression.Call(gbmi, parm, gbExpr);
    
            var TSelectInput = typeof(IGrouping<,>).MakeGenericType(prop.Type, TTElement);
            var separm = Expression.Parameter(TSelectInput, "p");
    
            var miKey = typeof(MenuItem).GetMember("Key").Single();
            var miCount = typeof(MenuItem).GetMember("Count").Single();
            var miItems = typeof(MenuItem).GetMember("Items").Single();
    
            Expression sepKey = Expression.Property(separm, "Key");
            if (sepKey.Type != typeof(string)) {
                var ctmi = sepKey.Type.GetMethod("ToString", Type.EmptyTypes);
                sepKey = Expression.Call(sepKey, ctmi);
            }
            var countmi = GetEnumerableMethod("Count", TTElement);
            var sepCount = Expression.Call(countmi, separm);
    
            var gbsmi = GetGenericMethod(MethodBase.GetCurrentMethod().DeclaringType, "GroupBySelector", new[] { TTElement }, new[] { TIETElement, typeof(IList<string>), typeof(int) });
            var sepItems = Expression.Call(gbsmi, separm, Expression.Constant(columnNames), Expression.Constant(nextEntry));
    
            var senew = Expression.New(typeof(MenuItem));
    
            var se1body = Expression.MemberInit(senew, new[] {
                            Expression.Bind(miKey, sepKey),
                            Expression.Bind(miCount, sepCount),
                            Expression.Bind(miItems, sepItems)
                        });
            var se1 = Expression.Lambda(se1body, separm);
    
            var se2body = Expression.MemberInit(senew, new[] {
                            Expression.Bind(miKey, sepKey),
                            Expression.Bind(miCount, sepCount)
                        });
            var se2 = Expression.Lambda(se2body, separm);
    
            var smi = GetEnumerableMethod("Select", TSelectInput, typeof(MenuItem));
            body = Expression.Call(smi, body, (nextEntry < columnNames.Count) ? se1: se2);
    
            var lmi = GetEnumerableMethod("ToList", typeof(MenuItem));
            body = Expression.Call(lmi, body);
    
            var returnFunc = Expression.Lambda<Func<IEnumerable<TElement>, List<MenuItem>>>(body, parm).Compile();
            return returnFunc(source);
        }
    }
