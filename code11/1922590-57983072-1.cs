    static MemberInfo tKey = typeof(TreeItem).GetMember("Key").Single();
    static MemberInfo tRawKey = typeof(TreeItem).GetMember("RawKey").Single();
    static MemberInfo tCount = typeof(TreeItem).GetMember("Count").Single();
    static MemberInfo tParentKey = typeof(TreeItem).GetMember("ParentKey").Single();
    static MemberInfo tItems = typeof(TreeItem).GetMember("Items").Single();
    // Concat(string, string, string)
    static MethodInfo Concat3MI = ((Func<string, string, string, string>)String.Concat).Method;
    // new TreeItem() { ... }
    static NewExpression newMenuItemExpr = Expression.New(typeof(TreeItem));
    // Enumerable.ToDictionary<TreeItem>(IEnumerable<TreeItem>, Func<TreeItem,string>)
    static MethodInfo ToDictionaryMI = GetEnumerableMethod("ToDictionary", typeof(TreeItem), typeof(string));
    static Expression<Func<IEnumerable<TElement>, Dictionary<string, TreeItem>>> BuildGroupBySelector<TElement>(IList<string> columnNames, int entry, Expression key) {
        List<string> columnParameters = columnNames[entry].Split('|').ToList();
        string columnName = columnParameters[0];
        if (columnName == null) throw new ArgumentNullException(nameof(columnName));
        if (columnName.Length == 0) throw new ArgumentException(nameof(columnName));
        int nextEntry = entry + 1;
        var tElement = typeof(TElement);
        var tIElement = typeof(IEnumerable<TElement>);
        // (TElement kp)
        var keyParm = Expression.Parameter(tElement, "kp");
        // kp.columnName
        var prop = Expression.Property(keyParm, columnName);
        // (IEnumerable<TElement> p)
        var IEParam = Expression.Parameter(tIElement, "p");
        // GroupBy<TElement>(IEnumerable<TElement>, Func<TElement, typeof(kp.columnName)>)
        var groupByMethod = GetEnumerableMethod("GroupBy", tElement, prop.Type);
        // kp => kp.columnName
        var groupByExpr = Expression.Lambda(prop, keyParm);
        // GroupBy(p, kp => kp.columnName)
        var bodyExprCall = Expression.Call(groupByMethod, IEParam, groupByExpr);
        // typeof(IGrouping<typeof(kp.columnName), TElement>)
        var tSelectInput = typeof(IGrouping<,>).MakeGenericType(prop.Type, tElement);
        // (IGrouping<typeof(kp.columnName), TElement> sp)
        var selectParam = Expression.Parameter(tSelectInput, "sp");
        // sp.Key
        Expression selectParamKey = Expression.Property(selectParam, "Key");
        Expression selectParamRawKey = selectParamKey;
        if (selectParamKey.Type != typeof(string)) {
            var toStringMethod = selectParamKey.Type.GetMethod("ToString", Type.EmptyTypes);
            // sp.Key.ToString()
            selectParamKey = Expression.Call(selectParamKey, toStringMethod);
            selectParamRawKey = selectParamKey;
        }
        // Count<TElement>()
        var countMethod = GetEnumerableMethod("Count", tElement);
        // sp.Count()
        var countMethodExpr = Expression.Call(countMethod, selectParam);
        LambdaExpression selectBodyExprLamba;
        if (nextEntry < columnNames.Count) {
            // Concat(key, "|", sp.Key.ToString())
            var concatFullKeyExpr = Expression.Call(Concat3MI, key, Expression.Constant("|"), selectParamRawKey);
            // p# => p#.GroupBy().Select().ToDictionary()
            var groupBySelectorLambdaExpr = BuildGroupBySelector<TElement>(columnNames, nextEntry, (Expression)concatFullKeyExpr);
            // Invoke(p# => p#..., sp#)
            var groupBySelectorInvokeExpr = Expression.Invoke(groupBySelectorLambdaExpr, selectParam);
            var selectBodyExpr = Expression.MemberInit(newMenuItemExpr, new[] {
                                                                                    Expression.Bind(tKey, selectParamKey),
                                                                                    Expression.Bind(tRawKey, selectParamRawKey),
                                                                                    Expression.Bind(tParentKey, key ),
                                                                                    Expression.Bind(tCount, countMethodExpr),
                                                                                    Expression.Bind(tItems, groupBySelectorInvokeExpr)
                                                                                 });
            // sp => new TreeItem { Key = sp.Key.ToString(), RawKey = sp.Key.ToString(), ParentKey = key, Count = sp.Count(), Items = Invoke(p# => p#..., sp)) }
            selectBodyExprLamba = Expression.Lambda(selectBodyExpr, selectParam);
        }
        else { // Last Level
            var selectBodyExpr = Expression.MemberInit(newMenuItemExpr, new[] {
                                                                                    Expression.Bind(tKey, selectParamKey),
                                                                                    Expression.Bind(tRawKey, selectParamRawKey),
                                                                                    Expression.Bind(tParentKey, key ),
                                                                                    Expression.Bind(tCount, countMethodExpr)
                                                                                    });
            // sp => new TreeItem { Key = sp.Key.ToString(), RawKey = sp.Key.ToString(), ParentKey = key, Count = sp.Count() }
            selectBodyExprLamba = Expression.Lambda(selectBodyExpr, selectParam);
        }
        // Enumerable.Select<IGrouping<typeof<kp.columnName>, TElement>>(IEnumerable<IGrouping<>>, Func<IGrouping<>, TreeItem>)
        var selectMethod = GetEnumerableMethod("Select", tSelectInput, typeof(TreeItem));
        // p.GroupBy(kp => kp => kp.columnName).Select(sp => ...)
        bodyExprCall = Expression.Call(selectMethod, bodyExprCall, selectBodyExprLamba);
        // (TreeItem o)
        var selectParamout = Expression.Parameter(typeof(TreeItem), "o");
        // o.FullKey
        Expression selectParamKeyout = Expression.Property(selectParamout, "FullKey");
        // o => o.FullKey
        var selectParamKeyLambda = Expression.Lambda(selectParamKeyout, selectParamout);
        // p.GroupBy(...).Select(...).ToDictionary(o => o.FullKey)
        bodyExprCall = Expression.Call(ToDictionaryMI, bodyExprCall, selectParamKeyLambda);
        // p => p.GroupBy(kp => kp => kp.columnName).Select(sp => ...).ToDictionary(o => o.FullKey)
        return Expression.Lambda<Func<IEnumerable<TElement>, Dictionary<string, TreeItem>>>(bodyExprCall, IEParam);
    }
    public static Dictionary<string, TreeItem> GroupBySelector<TElement>(IEnumerable<TElement> source, IList<string> columnNames, string key = "") {
        if (source == null) throw new ArgumentNullException(nameof(source));
        // p => p.GroupBy(kp => kp => kp.columnName).Select(sp => ...).ToDictionary(o => o.FullKey)
        var returnFunc = BuildGroupBySelector<TElement>(columnNames, 0, Expression.Constant(key)).Compile();
        return returnFunc(source);
    }
