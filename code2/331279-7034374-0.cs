    public class ExtendedDataAnnotationsModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        internal static DataAnnotationsModelValidationFactory DefaultAttributeFactory = Create;
        internal static Dictionary<Type, DataAnnotationsModelValidationFactory> AttributeFactories = new Dictionary<Type, DataAnnotationsModelValidationFactory>() 
        {
            {
                typeof(RegularExpressionAttribute),
                (metadata, context, attribute) => new RegularExpressionAttributeAdapter(metadata, context, (RegularExpressionAttribute)attribute)
            }
        };
        internal static ModelValidator Create(ModelMetadata metadata, ControllerContext context, ValidationAttribute attribute)
        {
            return new DataAnnotationsModelValidator(metadata, context, attribute);
        }
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            if(!attributes.Any(i => i is RegularExpressionAttribute))
            {
                if (typeof(DateTime).Equals(metadata.ModelType) || (metadata.ModelType.IsGenericType && typeof(DateTime).Equals(metadata.ModelType.GetGenericArguments()[0])))
                {
                    DataAnnotationsModelValidationFactory factory;
                    RegularExpressionAttribute regex = null;
                    switch (metadata.DataTypeName)
                    {
                        case "Date":
                            regex = new RegularExpressionAttribute(RegExPatterns.Date) { ErrorMessage = "Invalid date. Please use a m/d/yyyy format" };
                            break;
                        case "Time":
                            regex = new RegularExpressionAttribute(RegExPatterns.Time) { ErrorMessage = "Invalid time. Please use a h:mm format" };
                            break;
                        default: //DateTime
                            regex = new RegularExpressionAttribute(RegExPatterns.DateAndTime) { ErrorMessage = "Invalid date / time. Please use a m/d/yyyy h:mm format" };
                            break;
                    }
               
                    if (!AttributeFactories.TryGetValue(regex.GetType(), out factory))
                        factory = DefaultAttributeFactory;
                    yield return factory(metadata, context, regex);
                }
            }
        }
    }
