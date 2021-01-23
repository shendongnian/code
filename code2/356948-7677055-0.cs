    var listOfLists = new List<List<object>>();
    //... do list building...
    //types
    var runTimeType = typeof(MyRuntimeType);
    var innerListType = typeof(List<>)
        .MakeGenericType(typeof(object));
    var innerEnumerableType = typeof(IEnumerable<>)
        .MakeGenericType(runTimeType);
    var outerListType = typeof(List<>)
        .MakeGenericType(innerListType);
    //methods
    var castm = typeof(Enumerable).GetMethod("Cast")
        .MakeGenericMethod(runTimeType);
    var selectm = typeof(Enumerable).GetMethods()
        .Where(x => x.Name == "Select").First()
        .MakeGenericMethod(innerListType, innerEnumerableType);
    //expressions (parameters)
    var innerParamx = Expression.Parameter(innerListType);
    var outerParamx = Expression.Parameter(outerListType);
    // listOfLists.Select(x => x.Cast<T>()); 
    // as an expression
    var castx = Expression.Call(castm, innerParamx);
    var lambdax = Expression.Lambda(castx, innerParamx);
    var selectx = Expression.Call(selectm, outerParamx, lambdax);
    var lambdax2 = Expression.Lambda(selectx, outerParamx);
    var result = lambdax2.Compile().DynamicInvoke(listOfLists);
