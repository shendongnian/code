    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class MyCustomServerValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // remember to cast to the class type, not property type
            // ... return true or false
        }
    }
