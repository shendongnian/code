    public class OptionalRequired : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// The name of the client validation rule
        /// </summary>
        private readonly string type = "optionalrequired";
        /// <summary>
        /// The (minimum) ammount of properties that are required to be filled in. Use -1 when there is no minimum. Default 1.
        /// </summary>
        public int MinimumAmmount { get; set; } = 1;
        /// <summary>
        /// The maximum ammount of properties that need to be filled in. Use -1 when there is no maximum. Default -1.
        /// </summary>
        public int MaximumAmmount { get; set; } = -1;
        /// <summary>
        /// The collection of property names
        /// </summary>
        public string[] Properties { get; set; }
        public OptionalRequired(string[] properties)
        {
            Properties = properties;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int validPropertyValues = 0;
            // Iterate the properties in the collection
            foreach (var propertyName in Properties)
            {
                // Find the property
                var property = validationContext.ObjectType.GetProperty(propertyName);
                // When the property is not found throw an exception
                if (property == null)
                    throw new ArgumentException($"Property {propertyName} not found.");
                // Get the value of the property
                var propertyValue = property.GetValue(validationContext.ObjectInstance);
                // When the value is not null and not empty (very simple validation)
                if (propertyValue != null && String.IsNullOrEmpty(propertyValue.ToString()))
                    validPropertyValues++;
            }
            // Check if the minimum allowed is exceeded
            if (MinimumAmmount != -1 && validPropertyValues < MinimumAmmount)
                return new ValidationResult($"You are required to fill in a minimum of {MinimumAmmount} fields.");
            // Check if the maximum allowed is exceeded
            else if (MaximumAmmount != -1 && validPropertyValues > MaximumAmmount)
                return new ValidationResult($"You can only fill in {MaximumAmmount} of fields");
            // 
            else
                return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ErrorMessage = "Enter your error message here or manipulate it on the client side";
            rule.ValidationParameters.Add("minimum", MinimumAmmount);
            rule.ValidationParameters.Add("maximum", MaximumAmmount);
            rule.ValidationParameters.Add("properties", string.Join(",", Properties));
            rule.ValidationType = type;
            yield return rule;
        }
    }
