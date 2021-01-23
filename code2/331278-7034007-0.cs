    public class MyModelMetadataValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        internal static DataAnnotationsModelValidationFactory DefaultAttributeFactory = Create;
        internal static Dictionary<Type, DataAnnotationsModelValidationFactory> AttributeFactories = new Dictionary<Type, DataAnnotationsModelValidationFactory>() {
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
            List<ModelValidator> vals = base.GetValidators(metadata, context, attributes).ToList();
            // inject our new validator
            if (metadata.ModelType.Name == "DateTime")
            {
                DataAnnotationsModelValidationFactory factory;
                RegularExpressionAttribute regex = new RegularExpressionAttribute(
                    "^(((0?[1-9]|1[012])/(0?[1-9]|1\\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\\d)\\d{2}|0?2/29/((19|[2-9]\\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$");
                regex.ErrorMessage = "Invalid date format";
                if (!AttributeFactories.TryGetValue(regex.GetType(), out factory))
                    factory = DefaultAttributeFactory;
                vals.Add(factory(metadata, context, regex));
            }
            return vals.AsEnumerable();
        }
    }
