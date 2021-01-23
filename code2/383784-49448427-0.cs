    [AttributeUsage(AttributeTargets.Property |
                    AttributeTargets.Field, AllowMultiple = false)]
    public sealed class RequiredStringListAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (!(value is List<string> list))
                return new ValidationResult($"The required attrribute must be of type List<string>");
            bool valid = false;
            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item))
                    valid = true;
            }
            return valid
                ? ValidationResult.Success
                : new ValidationResult($"This field is required"); ;
        }
    }
