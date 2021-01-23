        string stateValue = "Pendiente";
        ValidationAttributeValidator<ConfirmationTemporalIncapacityEntry, RequiredAttribute> validator =
            new ValidationAttributeValidator<ConfirmationTemporalIncapacityEntry, RequiredAttribute>();
        Assert.IsTrue(validator.ValidateValidationAttribute("State", stateValue));
    public class ValidationAttributeValidator<T,A>
        {
            public ValidationAttributeValidator() { }
    
            public bool ValidateValidationAttribute(string property, object value)
            {
                var propertyInfo = typeof(T).GetProperty(property);
                var validationAttributes = propertyInfo.GetCustomAttributes(true);
    
                if (validationAttributes == null)
                {
                    return false; 
                }
                List<ValidationAttribute> validationAttributeList = new List<ValidationAttribute>();
                foreach (object attribute in validationAttributes)
                {
                    if (attribute.GetType() == typeof(A))
                    {
                        validationAttributeList.Add((ValidationAttribute)attribute);
                    }
                }
                return(validationAttributeList.Exists(x => x.IsValid(value)));
            }
        }
