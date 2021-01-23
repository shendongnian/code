    /// <summary>
    /// Attribute for validation of nested complex type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateComplexTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return DataValidator.IsValid(value);
        }
    }
