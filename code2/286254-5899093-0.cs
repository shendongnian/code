     public IEnumerable<ErrorInfo> GetErrors() {
                return from prop in TypeDescriptor.GetProperties(this).Cast<PropertyDescriptor>()
                       from attribute in prop.Attributes.OfType<ValidationAttribute>()
                       where !attribute.IsValid(prop.GetValue(this))
                       select new ErrorInfo(prop.Name, attribute.FormatErrorMessage(string.Empty));
            }
