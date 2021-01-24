    List<int> list = new List<int>();
    for (int i = 0; i< 12; i++)
    {
        list.Add(i);
    }
    MethodInfo[] mis = typeof(System.Linq.Enumerable).GetMethods();
    MethodInfo miAny = mis.FirstOrDefault(d => d.Name == "Any" && d.GetParameters().Count() == 2);
    Func<int, bool> func = c => c > 10;
    MethodInfo gf = miAny.MakeGenericMethod(new Type[] { typeof(int) });
    bool any = (bool)gf.Invoke(null, new object[] { list, func });
