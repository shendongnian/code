    private static readonly Type[] tupleTypes = new[]
    {
        typeof(ValueTuple<>), typeof(ValueTuple<,>), typeof(ValueTuple<,,>),
        typeof(ValueTuple<,,,>), typeof(ValueTuple<,,,,>), typeof(ValueTuple<,,,,,>),
        typeof(ValueTuple<,,,,,,>), typeof(ValueTuple<,,,,,,,>)
    };
    public static bool IsListOfValueTuple(Type type)
    {
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
        {
            var arg = type.GetGenericArguments()[0];
            return arg.IsGenericType && tupleTypes.Contains(arg.GetGenericTypeDefinition());
        }
        return false;
    }
    public static void Main()
    {
        Console.WriteLine(IsListOfValueTuple(typeof(List<(string, int)>)));
    }
