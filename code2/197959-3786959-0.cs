    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class RequiredAsSetAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var properties = TypeDescriptor.GetProperties(value);
            ...
        }
    }
