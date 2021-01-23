    protected void Application_Start()
    {
        ModelValidatorProviders.Providers.Add(new ZipValidationProvider());
    }
    public class ZipValidationProvider:AssociatedValidatorProvider
    {
        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            foreach (var attribute in attributes.OfType<EitherPropertyRequiredAttribute>())
            {
                yield return new EitherPropertyRequiredValidator(metadata,
                    context, attribute.FirstProperty, attribute.SecondProperty, attribute.Message);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class EitherPropertyRequiredAttribute : Attribute
    {
        public readonly string FirstProperty;
        public readonly string SecondProperty;
        public readonly string Message;
        public EitherPropertyRequiredAttribute(string firstProperty, string secondProperty, 
            string message)
        {
            FirstProperty = firstProperty;
            SecondProperty = secondProperty;
            Message = message;
        }
    }
    public class EitherPropertyRequiredValidator:ModelValidator
    {
        private readonly string firstProperty;
        private readonly string secondProperty;
        private readonly string message;
        public EitherPropertyRequiredValidator(ModelMetadata metadata,
                                        ControllerContext context,
            string firstProperty, 
            string secondProperty,
            string message)
            :base(metadata,context)
        {
            this.firstProperty = firstProperty;
            this.secondProperty = secondProperty;
            this.message = message;
        }
        private PropertyInfo GetPropertyInfoRecursive(Type type, string property)
        {
            var prop = type.GetProperty(property);
            if (prop != null) return prop;
            foreach (var p in type.GetProperties())
            {
                if (p.PropertyType.Assembly == typeof (object).Assembly)
                    continue;
                return GetPropertyInfoRecursive(p.PropertyType, property);
            }
            return null;
        }
        private object GetPropertyValueRecursive(object obj, PropertyInfo propertyInfo)
        {
            Type objectType = obj.GetType();
           if(objectType.GetProperty(propertyInfo.Name) != null)
                return propertyInfo.GetValue(obj, null);
            foreach (var p in objectType.GetProperties())
            {
                if (p.PropertyType.Assembly == typeof(object).Assembly)
                    continue;
                var o = p.GetValue(obj,null);
                return GetPropertyValueRecursive(o, propertyInfo);
            }
            return null;
        }
        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            if (Metadata.Model == null)
                yield break;
            var firstPropertyInfo = GetPropertyInfoRecursive(Metadata.Model.GetType(),firstProperty);
            if(firstPropertyInfo == null)
                throw new InvalidOperationException("Unknown property:" + firstProperty);
            var secondPropertyInfo = GetPropertyInfoRecursive(Metadata.Model.GetType(),secondProperty);
            if(secondPropertyInfo == null)
                throw new InvalidOperationException("Unknown property:" + secondProperty);
            var firstPropertyValue = GetPropertyValueRecursive(Metadata.Model, firstPropertyInfo);
            var secondPropertyValue = GetPropertyValueRecursive(Metadata.Model, secondPropertyInfo);
            bool firstPropertyIsEmpty = firstPropertyValue == null ||
                                        firstPropertyValue.ToString().Length == 0;
            bool secondPropertyIsEmpty = secondPropertyValue == null ||
                                         secondPropertyValue.ToString().Length == 0;
            if (firstPropertyIsEmpty && secondPropertyIsEmpty)
            {
                    yield return new ModelValidationResult
                    {
                        MemberName = firstProperty,
                        Message = message
                    };
            }
        }
    }
