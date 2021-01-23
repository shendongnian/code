    public static unsafe Array CreateInstance(Type elementType, int length)
    {
        if (elementType == null)
        {
            throw new ArgumentNullException("elementType");
        }
        RuntimeType underlyingSystemType = elementType.UnderlyingSystemType as RuntimeType;
        if (underlyingSystemType == null)
        {
            throw new ArgumentException(Environment.GetResourceString("Arg_MustBeType"), "elementType");
        }
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException("length", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
        }
        return InternalCreate((void*) underlyingSystemType.TypeHandle.Value, 1, &length, null);
    }
 
