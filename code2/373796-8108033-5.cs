    public static Property<T> AsProp<T>(this T value, string name)
    {
        return new Property<T>(name,value);
    }
    
    var intProp = 32.AsProp("age");
    var strProp = "Earl".AsProp("name");
    var enumProp = ColorEnum.Magenta.AsProp("eye color");
