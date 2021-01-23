    //Cache the generated method for re-use later, say as a static field of dictionary. It shouldn't grow too-big given the number of overloads of Write.
    private static Dictionary<Type, Action<BinaryWriter, object>> _lambdaCache = new Dictionary<Type, Action<BinaryWriter, object>>();
    //...
    if (!_lambdaCache.ContainsKey(fi.FieldType))
    {
        var binaryWriterParameter = Expression.Parameter(typeof(BinaryWriter));
        var valueParameter = Expression.Parameter(typeof(object));
        var call = Expression.Call(binaryWriterParameter, "Write", null, Expression.Convert(valueParameter, fi.FieldType));
        var lambda = Expression.Lambda<Action<BinaryWriter, object>>(call, binaryWriterParameter, valueParameter).Compile();
        _lambdaCache.Add(fi.FieldType, lambda);
    }
    var write = _lambdaCache[fi.FieldType];
    write(bw, fi.GetValue(obj));
