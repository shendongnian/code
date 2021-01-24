    public static IList<T> ToInterfacedObjects<T>(this IEnumerable<T> data) where T : class
    {
        var myType = MakeDynamicType<T>();
        var list = new List<T>();
        foreach (var datum in data)
        {
            var obj = (T)Activator.CreateInstance(myType);
            foreach (var pi in typeof(T).GetProperties())
            {
                var val = pi.GetValue(datum);
                pi.SetValue(obj, val);
                list.Add(obj);
            }
        }
        return list;
    }
 
