    public static string GetAString(object o)
    {
        System.Reflection.PropertyInfo name = o.GetType().GetProperty("name");
        return (string) name.GetValue(o, null);
    } 
