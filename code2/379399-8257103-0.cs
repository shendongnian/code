    public static string GetAString(object o){
        Type t = o.GetType();
 
        System.Reflection.PropertyInfo name = t.GetProperty("name");
        return (string) (name.GetValue(o,null));
    } 
