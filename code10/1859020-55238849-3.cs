    public static object CreateValueTuple<T>(ICollection<T> collection)
    {
        object[] items;
        Type[] parameterTypes;
        if (collection.Count <= 7)
        {
            items = collection.Cast<object>().ToArray();
            parameterTypes = Enumerable.Repeat(typeof(T), collection.Count).ToArray();
        }
        else
        {
            var rest = CreateValueTuple(collection.Skip(7).ToArray());
            items = collection.Take(7).Cast<object>().Append(rest).ToArray();
            parameterTypes = Enumerable.Repeat(typeof(T), 7).Append(rest.GetType()).ToArray();
        }
        var createMethod = typeof(ValueTuple).GetMethods()
            .Where(m => m.Name == "Create" && m.GetParameters().Length == items.Length)
            .SingleOrDefault() ?? throw new NotSupportedException("ValueTuple.Create method not found.");
        var createGenericMethod = createMethod.MakeGenericMethod(parameterTypes);
        var valueTuple = createGenericMethod.Invoke(null, items);
        return valueTuple;
    }
