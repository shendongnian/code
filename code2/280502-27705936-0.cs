    static class Metadata<T>
    {
        static public readonly Type Type = typeof(T);
        static public readonly bool IsValueType = Metadata<T>.Type.IsValueType;
    }
    
    //fast test if T is ValueType
    if(Metadata<T>.IsValueType) //only read static readonly field!
    {
        //...
    }
