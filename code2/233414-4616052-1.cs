    public delegate void CLIBDelegate(object);
    // handlers for types that will call the appropriate CLIB_XXX function:
    public void CLIB_int(object _obj);
    public void CLIB_string(object _obj);
    // etc...
    // Our dictionary:
    Dictionary<System.Type, CLIBDelegate> dict = new Dictionary<System.Type, CLIBDelegate>();
    dict[typeof(System.Int32)] = CLIB_int;
    dict[typeof(System.string] = CLIB_string;
    // etc...
    // your set function
    void Set(Object _object)
    {
        if(dict.ContainsKey(_object.GetType())
            dict[_object.GetType()](_object);
    } // eo Set
