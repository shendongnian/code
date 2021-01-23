    Type t = typeof(MyType);
    PropertyInfo pi = t.GetProperty("Foo");
    object value = pi.GetValue(null, null);
    class MyType
    {
     public static string Foo
     {
       get { return "bar"; }
     } 
    }
