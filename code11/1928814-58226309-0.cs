 c#
static void Main()
{
    Console.WriteLine(FindFirstIEnumerable(typeof(int))); // null
    Console.WriteLine(FindFirstIEnumerable(typeof(string))); // System.Char
    Console.WriteLine(FindFirstIEnumerable(typeof(Guid[]))); // System.Guid
    Console.WriteLine(FindFirstIEnumerable(typeof(IEnumerable<float>))); // System.Single
}
static Type FindFirstIEnumerable(Type type)
{
    if (type == null || !typeof(IEnumerable).IsAssignableFrom(type))
        return null; // anything IEnumerable<T> *must* be IEnumerable
    if (type.IsInterface && type.IsGenericType
        && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
    {
        return type.GetGenericArguments()[0];
    }
    foreach(var iType in type.GetInterfaces())
    {
        if (iType.IsGenericType &&
            iType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
        {
            return iType.GetGenericArguments()[0];
        }
    }
    return null;
}
