    Type t = myDerivedAB.GetType();
    if (t.IsGenericType)
    {
        Type[] typeArguments = t.GetGenericArguments();
        Debug.Assert(typeArguments.Length > 0 && typeArguments[0] is IB);
    }
