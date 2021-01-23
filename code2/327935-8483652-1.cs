        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error { get { return this[""]; } }
        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="memberName">The name of the property whose error message to get.</param>
        /// <returns>The error message for the property. The default is an empty string ("").</returns>
        public string this[string memberName]
        {
            get
            {
                List<ValidationResult> validationResults = new List<ValidationResult>();
                if (string.IsNullOrEmpty(memberName))
                {
                    Validator.TryValidateObject(instance, new ValidationContext(instance, null, null), validationResults, true);
                }
                else
                {
                    PropertyDescriptor property = TypeDescriptor.GetProperties(instance)[memberName];
                    if (property == null)
                    {
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                            "The specified member {0} was not found on the instance {1}", memberName, instance.GetType()));
                    }
                    Validator.TryValidateProperty(property.GetValue(instance),
                        new ValidationContext(instance, null, null) { MemberName = memberName }, validationResults);
                }
                StringBuilder errorBuilder = new StringBuilder();
                foreach (ValidationResult validationResult in validationResults)
                {
                    errorBuilder.AppendInNewLine(validationResult.ErrorMessage);
                }
                return errorBuilder.ToString();
            }
        }
