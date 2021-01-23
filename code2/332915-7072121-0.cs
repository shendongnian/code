    public static Type GetEnumerableType(Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            return type.GetGenericArguments()[0];
        var iface = (from i in type.GetInterfaces()
                     where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                     select i).FirstOrDefault();
        if (iface == null)
            throw new ArgumentException("Does not represent an enumerable type.", "type");
        return GetEnumerableType(iface);
    }
