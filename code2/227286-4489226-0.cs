    public class ListValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            IEnumerable enumerable = value as IEnumerable;
            // If the input object is not enumerable it's considered valid.
            if (enumerable == null)
            {
                return true;
            }
            foreach (object item in enumerable)
            {
                // Get all properties on the current item with at least one
                // ValidationAttribute defined.
                IEnumerable<PropertyInfo> properties = item.GetType().
                    GetProperties().Where(p => p.GetCustomAttributes(
                    typeof(ValidationAttribute), true).Count() > 0);
                foreach (PropertyInfo property in properties)
                {
                    // Validate each property.
                    IEnumerable<ValidationAttribute> validationAttributes =
                        property.GetCustomAttributes(typeof(ValidationAttribute),
                        true).Cast<ValidationAttribute>();
                    foreach (ValidationAttribute validationAttribute in
                        validationAttributes)
                    {
                        object propertyValue = property.GetValue(item, null);
                        if (!validationAttribute.IsValid(propertyValue))
                        {
                            // Return false if one value is found to be invalid.
                            return false;
                        }
                    }
                }
            }
            // If everything is valid, return true.
            return true;
        }
    }
