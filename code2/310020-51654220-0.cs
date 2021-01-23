    var typeConvertedEnumerable = typeof(System.Linq.Enumerable)
        .GetMethod("Cast", BindingFlags.Static | BindingFlags.Public)
        .MakeGenericMethod(new Type[] { myType })
        .Invoke(null, new object[] { myArray });
    var typeConvertedArray = typeof(System.Linq.Enumerable)
        .GetMethod("ToArray", BindingFlags.Static | BindingFlags.Public)
        .MakeGenericMethod(new Type[] { myType })
        .Invoke(null, new object[] { typeConvertedEnumerable });
