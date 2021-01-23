    public static Property<T> MakeProperty(string name, T value)
    {
        return new Property<T>(name,value);
    }
    var intProp = MakeProperty("age", 32);    
    var strProp = MakeProperty("name", "Earl");    
    var enumProp = MakeProperty("eye color", ColorEnum.Magenta);    
