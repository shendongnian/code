    static class StringExtensions
    {
       private static readonly Func<object, string, Action<object, object>> GetSetter =
           (o1, n) => (o2, v) => o1.GetType().GetProperty(n).SetValue(o2, v, null);
    
       public static T AssignFromCSV<T>(this string csv, T obj, string[] propertyNames)
       {
           var a = csv.Split(new[] {','});
           for (var i = 0 ; i < propertyNames.Length; i++)
           {
               GetSetter(obj, propertyNames[i])(obj, a[i]);
           }
    	   return obj ;
       }
    }
    	
    class TargetClass
    {
       public string A { get; set; }
    
       public string B { get; set; }
    
       public string C { get; set; }
    }
