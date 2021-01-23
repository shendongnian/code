    public static Type ToType(this string str)
    {
        return Type.GetType(str, null, null);
    }
    ...
   
    string myType = "System.Int32";        
    bool test1 = CanConvert<myType.ToType()>("123");      //true    
    bool test2 = CanConvert<myType.ToType()>("hello");    // false
