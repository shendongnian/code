    /// in class MyClass { 
    IEnumerable<IEnumerable<T>> castList<T>(List<List<object>> list) {
        return list.Select(x => x.Cast<T>());
    }
    ...
    // make a list<list<object>> that contains int
    var list = new List<List<object>> { new List<object> { 1, 2, 3, 4, 5 } };
    // get our type to convert to
    var type = typeof(int);
    // use reflection to convert.
    var ienumerable = (IEnumerable<IEnumerable<int>>)typeof(MyClass).GetMethod("castList")
        .MakeGenericMethod(type)
        .Invoke(null, new[] { list });
