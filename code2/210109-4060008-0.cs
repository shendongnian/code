    [AttributeUsage(AttributeTargets.Field,  AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class MyCustomAttribute : ValidationAttribute
    {
      public MyCustomAttribute()
        : base("Custom Error Message: {0}")
      {
      }
    
      public override bool IsValid(object value)
      {
        return true;
      }
    }
