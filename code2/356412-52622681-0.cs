        public bool TryValidateObject(object obj, ICollection<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj, null, validationContextItems), results, true);
        }
        public bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return TryValidateObjectRecursive(obj, results, new HashSet<object>(), validationContextItems);
        }
        private bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, ISet<object> validatedObjects, IDictionary<object, object> validationContextItems = null)
        {
            //short-circuit to avoid infinit loops on cyclical object graphs
            if (validatedObjects.Contains(obj))
            {
                return true;
            }
            validatedObjects.Add(obj);
            bool result = TryValidateObject(obj, results, validationContextItems);
            var properties = obj.GetType().GetProperties().Where(prop => prop.CanRead
                && !prop.GetCustomAttributes(typeof(SkipRecursiveValidation), false).Any()
                && prop.GetIndexParameters().Length == 0).ToList();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string) || property.PropertyType.IsValueType) continue;
                var value = obj.GetPropertyValue(property.Name);
                if (value == null) continue;
                var asEnumerable = value as IEnumerable;
                if (asEnumerable != null)
                {
                    foreach (var enumObj in asEnumerable)
                    {
                        if ( enumObj != null) {
                           var nestedResults = new List<ValidationResult>();
                           if (!TryValidateObjectRecursive(enumObj, nestedResults, validatedObjects, validationContextItems))
                           {
                               result = false;
                               foreach (var validationResult in nestedResults)
                               {
                                   PropertyInfo property1 = property;
                                   results.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property1.Name + '.' + x)));
                               }
                           };
                        }
                    }
                }
                else
                {
                    var nestedResults = new List<ValidationResult>();
                    if (!TryValidateObjectRecursive(value, nestedResults, validatedObjects, validationContextItems))
                    {
                        result = false;
                        foreach (var validationResult in nestedResults)
                        {
                            PropertyInfo property1 = property;
                            results.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property1.Name + '.' + x)));
                        }
                    };
                }
            }
            return result;
        }
    }
    public class ValidateObjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(value, null, null);
            Validator.TryValidateObject(value, context, results, true);
            if (results.Count != 0)
            {
                var compositeResults = new CompositeValidationResult(String.Format("Validation for {0} failed!", validationContext.DisplayName));
                results.ForEach(compositeResults.AddResult);
                return compositeResults;
            }
            return ValidationResult.Success;
        }
    }
    public class ValidateCollectionAttribute : ValidationAttribute
    {
        public Type ValidationType { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var collectionResults = new CompositeValidationResult(String.Format("Validation for {0} failed!",
                           validationContext.DisplayName));
            var enumerable = value as IEnumerable;
            var validators = GetValidators().ToList();
            if (enumerable != null)
            {
                var index = 0;
                foreach (var val in enumerable)
                {
                    var results = new List<ValidationResult>();
                    var context = new ValidationContext(val, validationContext.ServiceContainer, null);
                    if (ValidationType != null)
                    {
                        Validator.TryValidateValue(val, context, results, validators);
                    }
                    else
                    {
                        Validator.TryValidateObject(val, context, results, true);
                    }
                    if (results.Count != 0)
                    {
                        var compositeResults =
                           new CompositeValidationResult(String.Format("Validation for {0}[{1}] failed!",
                              validationContext.DisplayName, index));
                        results.ForEach(compositeResults.AddResult);
                        collectionResults.AddResult(compositeResults);
                    }
                    index++;
                }
            }
            if (collectionResults.Results.Any())
            {
                return collectionResults;
            }
            return ValidationResult.Success;
        }
        private IEnumerable<ValidationAttribute> GetValidators()
        {
            if (ValidationType == null) yield break;
            yield return (ValidationAttribute)Activator.CreateInstance(ValidationType);
        }
    }
    public class CompositeValidationResult : ValidationResult
    {
        private readonly List<ValidationResult> _results = new List<ValidationResult>();
        public IEnumerable<ValidationResult> Results
        {
            get
            {
                return _results;
            }
        }
        public CompositeValidationResult(string errorMessage) : base(errorMessage) { }
        public CompositeValidationResult(string errorMessage, IEnumerable<string> memberNames) : base(errorMessage, memberNames) { }
        protected CompositeValidationResult(ValidationResult validationResult) : base(validationResult) { }
        public void AddResult(ValidationResult validationResult)
        {
            _results.Add(validationResult);
        }
    }
    public interface IDataAnnotationsValidator
    {
        bool TryValidateObject(object obj, ICollection<ValidationResult> results, IDictionary<object, object> validationContextItems = null);
        bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, IDictionary<object, object> validationContextItems = null);
    }
    public static class ObjectExtensions
    {
        public static object GetPropertyValue(this object o, string propertyName)
        {
            object objValue = string.Empty;
            var propertyInfo = o.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
                objValue = propertyInfo.GetValue(o, null);
            return objValue;
        }
    }
    public class SkipRecursiveValidation : Attribute
    {
    }
    public class SaveValidationContextAttribute : ValidationAttribute
    {
        public static IList<ValidationContext> SavedContexts = new List<ValidationContext>();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            SavedContexts.Add(validationContext);
            return ValidationResult.Success;
        }
    }
