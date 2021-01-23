    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class OneOfAttribute : ValidationAttribute
    {
        public ValidationAttribute[] Validators { get; set; }
        public OneOfAttribute(params Type[] validatorTypes)
        {
            Validators = validatorTypes.Select(Activator.CreateInstance)
                .OfType<ValidationAttribute>()
                .ToArray();
            // just to make sure this was correctly invoked
            if (validatorTypes.Length != Validators.Length)
            {
                throw new ArgumentException("Invalid validation attribute type");
            }
        }
        public override bool IsValid(object value)
        {
            return Validators.Any(v => v.IsValid(value));
        }
    }
