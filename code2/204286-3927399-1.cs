    // map CLR types to convert methods; you'll need one entry in
    // this map for every CLR type
    private static readonly Dictionary<Type, Func<string, object>> TypeConverterMap =
        new Dictionary<Type, Func<string, object>>
    {
        { typeof(bool), x => Convert.ToBoolean(x)},
        { typeof(int), x => Convert.ToInt32(x)},
        { typeof(string), x => x},
        { typeof(double), x => Convert.ToDouble(x)}
    };
