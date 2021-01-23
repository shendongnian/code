    public static class SClass
    {
       public static class SInner
       {
           public static string Property = 
                (typeof(SInner)).DeclaringType.Name+ "." 
                + typeof(SInner).Name + "."
                + "value";
       }
    }
