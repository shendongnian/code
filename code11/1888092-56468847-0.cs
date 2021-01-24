    static void AddIfSameType<TLProp,TRProp>(Func<DataObject,TLProp> lprop, TRProp rprop) where TRProp : TLProp
    {
       
    }
    static void Main(string[] args)
    {
        AddIfSameType(d => d.IntProperty, 1);
        //compiles
        AddIfSameType(d => d.IntProperty, 1L); 
        //Error CS0315  The type 'long' cannot be used as type parameter 'TRProp' 
        //... There is no boxing conversion from 'long' to 'int'.
    }
