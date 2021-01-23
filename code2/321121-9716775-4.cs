    ParameterExpression dictExpr = Expression.Parameter(typeof(Dictionary<string, int>));
    ParameterExpression keyExpr = Expression.Parameter(typeof(string));
    ParameterExpression valueExpr = Expression.Parameter(typeof(int));
    // Simple and direct. Should normally be enough
    // PropertyInfo indexer = dictExpr.Type.GetProperty("Item");
    // Alternative, note that we could even look for the type of parameters, if there are indexer overloads.
    PropertyInfo indexer = (from p in dictExpr.Type.GetDefaultMembers().OfType<PropertyInfo>()
                            // This check is probably useless. You can't overload on return value in C#.
                            where p.PropertyType == typeof(int)
                            let q = p.GetIndexParameters()
                            // Here we can search for the exact overload. Length is the number of "parameters" of the indexer, and then we can check for their type.
                            where q.Length == 1 && q[0].ParameterType == typeof(string)
                            select p).Single();
    IndexExpression indexExpr = Expression.Property(dictExpr, indexer, keyExpr);
    BinaryExpression assign = Expression.Assign(indexExpr, valueExpr);
    var lambdaSetter = Expression.Lambda<Action<Dictionary<string, int>, string, int>>(assign, dictExpr, keyExpr, valueExpr);
    var lambdaGetter = Expression.Lambda<Func<Dictionary<string, int>, string, int>>(indexExpr, dictExpr, keyExpr);
    var setter = lambdaSetter.Compile();
    var getter = lambdaGetter.Compile();
    var dict = new Dictionary<string, int>();
    setter(dict, "MyKey", 2);
    var value = getter(dict, "MyKey");
