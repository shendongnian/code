    // Must be defined inside a class called Farenheit:
    public static explicit operator Celsius(Fahrenheit f)
    {
        return new Celsius((5.0f / 9.0f) * (f.degrees - 32));
    }
    Fahrenheit f = new Fahrenheit(100.0f);    
    Console.Write("{0} fahrenheit", f.Degrees);    
    Celsius c = (Celsius)f;
