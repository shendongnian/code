        [DefaultProperty("Text")]
        [ToolboxData("<{0}:DataAnnotationValidator runat=server></{0}:DataAnnotationValidator>")]
        public class DataAnnotationValidator : BaseValidator
        {
            #region Properties
    
            /// <summary>
            /// The type of the source to check
            /// </summary>
            public string SourceTypeName { get; set; }
    
            /// <summary>
            /// The property that is annotated
            /// </summary>
            public string PropertyName { get; set; }
    
            #endregion
    
            #region Methods
    
            protected override bool EvaluateIsValid()
            {
                // get the type that we are going to validate
                Type source = GetValidatedType();
    
                // get the property to validate
                FieldInfo property = GetValidatedProperty(source);
    
                // get the control validation value
                string value = GetControlValidationValue(ControlToValidate);
    
                foreach (var attribute in property.GetCustomAttributes(
                         typeof(ValidationAttribute), true)
                           .OfType<ValidationAttribute>())
                {
                    if (!attribute.IsValid(value))
                    {
                        ErrorMessage = attribute.ErrorMessage;
                        return false;
                    }
                }
                return true;
            }
    
            private Type GetValidatedType()
            {
                if (string.IsNullOrEmpty(SourceTypeName))
                {
                    throw new InvalidOperationException(
                      "Null SourceTypeName can't be validated");
                }
    
                Type validatedType = Type.GetType(SourceTypeName);
                if (validatedType == null)
                {
                    throw new InvalidOperationException(
                        string.Format("{0}:{1}",
                          "Invalid SourceTypeName", SourceTypeName));
                }
    
                IEnumerable<MetadataTypeAttribute> mt = validatedType.GetCustomAttributes(typeof(MetadataTypeAttribute), false).OfType<MetadataTypeAttribute>();
                if (mt.Count() > 0)
                {
                    validatedType = mt.First().MetadataClassType;
                }
    
                return validatedType;
            }
    
            private FieldInfo GetValidatedProperty(Type source)
            {
                FieldInfo field = source.GetField(PropertyName);
                if (field == null)
                {
                    throw new InvalidOperationException(
                      string.Format("{0}:{1}",
                        "Validated Property Does Not Exists", PropertyName));
                }
                return field;
            }
    
            #endregion
        }
