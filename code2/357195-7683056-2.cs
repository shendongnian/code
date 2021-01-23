    static MethodInfo[] readers = typeof(BinaryReader).GetTypeInfo()
        .DeclaredMethods
        .Where(m => m.Name.StartsWith("Read") && !m.GetParameters().Any())
        .ToArray();
    // Action for a given struct that reads each field from a BinaryReader
    static Func<BinaryReader, T> CreateReader<T>()
    {
        // TODO: cache/validate T is a "simple" struct
        var br = Expression.Parameter(typeof(BinaryReader), "br");
        var info = typeof(T).GetTypeInfo();
        var body = Expression.New(
           info.DeclaredConstructors.First(),
           new Expression[0], // no parameters
           from f in info.DeclaredFields
           select Expression.Bind(
               f,
               Expression.Call(
                   br,
                   readers.Single(m => m.ReturnType == f.FieldType),
                   Type.EmptyTypes, // Not a generic method
                   new Expression[0]));
        var function = Expression.Lambda<Func<BinaryReader, T>>(
            body,
            new[] { br });
        return function.Compile();
    }
