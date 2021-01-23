    public static class Extensions
    {
       public static int? ToNullableInt(this string arg)
       {
           int result;
           if (int.TryParse(arg, out result))
           {
               return result;
           }
           return null;
        }
    }
    
