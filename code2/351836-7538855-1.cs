    Type enumerableType = typeof(Enumerable);
    MemberInfo[] members = enumerableType.GetMember("Where*");
    MethodInfo whereDef = (MethodInfo)members[0]; // Where<TSource>(IEnumerable<TSource, Func<TSource,Boolean>)
    Type TSource = whereDef.GetGenericArguments()[0]; // TSource is the only generic argument
    Type[] types = { typeof(IEnumerable<>).MakeGenericType(TSource), typeof(Func<,>).MakeGenericType(TSource, typeof(Boolean)) };
    MethodInfo method = enumerableType.GetMethod("Where", types);
