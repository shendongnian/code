    // Action for a given struct that writes each field to a BinaryWriter
    static Action<BinaryWriter, T> CreateWriter<T>()
    {
        // TODO: cache/validate T is a "simple" struct
        var bw = Expression.Parameter(typeof(BinaryWriter), "bw");
        var obj = Expression.Parameter(typeof(T), "value");
        // I could not determine if .Net for Metro had BlockExpression or not
        // and if it does not you'll need a shim that returns a dummy value
        // to compose with addition or boolean operations
        var body = Expression.Block(
           from f in typeof(T).GetTypeInfo().DeclaredFields
           select Expression.Call(
               bw,
               "Write",
               Type.EmptyTypes, // Not a generic method
               new[] { Expression.Field(obj, f.Name) }));
        var action = Expression.Lambda<Action<BinaryWriter, T>>(
            body,
            new[] { bw, obj });
        return action.Compile();
    }
