    [AttributeUsage(AttributeTargets.Class)]
    public class MatchAttribute : ValidationAttribute
    {
       public override Boolean IsValid(Object value)
       {
            Type objectType = value.GetType();
      
            PropertyInfo[] properties = objectType.GetProperties();
            ...
       }
    }
