    public class C1<A,B> {}
    
    public class C2<B>: C1<int, B> {}
    
    [...]
    Type baseType = typeof(C2<>).BaseType;
    WL(baseType);
    WL(baseType.GetGenericArguments()[0]);
    Type arg1 = baseType.GetGenericArguments()[1];
    WL(arg1);
    WL(arg1.DeclaringType);
    WL(arg1.GenericParameterPosition);
    WL(arg1.IsGenericParameter);
