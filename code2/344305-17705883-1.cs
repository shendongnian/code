    private static object DynamicCast(object source, Type destType) {
        Type srcType = source.GetType();
        if (srcType == destType) return source;
        var paramTypes = new Type[] { srcType };
        MethodInfo cast = srcType.GetMethod("op_Implicit", paramTypes);
        if (cast == null) {
            cast = srcType.GetMethod("op_Explicit", paramTypes);
        }
        if (cast == null) {
            if (destType.IsEnum) return Enum.ToObject(destType, source);
            throw new InvalidCastException();
        }
        return cast.Invoke(null, new object[] { source });
    }
