    public static class MyConvert 
    {
         public static object? ChangeType(object? value, Type conversionType, IFormatProvider provider)
         {
             if (conversionType == typeof(decimal))
                 return decimal.Parse(value.ToString(), NumberStyles.Any, provider);
             else
                 return Convert.ChangeType(value, conversionType, provider);
         }
    } 
