    private static readonly Type[] generictupletypes = new Type[]
    {
        typeof(Tuple<>),
        typeof(Tuple<,>),
        typeof(Tuple<,,>),
        typeof(Tuple<,,,>),
        typeof(Tuple<,,,,>),
        typeof(Tuple<,,,,,>),
        typeof(Tuple<,,,,,,>),
        typeof(Tuple<,,,,,,,>)
    };
    public static Type GetGenericTupleType(int argumentsCount)
    {
        return generictupletypes[argumentsCount];
    }
