    public abstract class DataErrorInfo : IDataErrorInfo
    {
        public string Error
        {
            get { return null; }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get { return ValidateProperty(columnName); }
        }
        protected virtual string ValidateProperty(string columnName)
        {
             // get cached property accessors
                var propertyGetters = GetPropertyGetterLookups(GetType());
                if (propertyGetters.ContainsKey(columnName))
                {
                    // read value of given property
                    var value = propertyGetters[columnName](this);
                    // run validation
                    var results = new List<ValidationResult>();
                    var vc = new ValidationContext(this, null, null) { MemberName = columnName };
                    Validator.TryValidateProperty(value, vc, results);
                    // transpose results
                    var errors = Array.ConvertAll(results.ToArray(), o => o.ErrorMessage);
                    return string.Join(Environment.NewLine, errors);
                }
                return string.Empty;
        }
        
        private static readonly Dictionary<string, object> PropertyLookupCache =
            new Dictionary<string, object>();
        private static Dictionary<string, Func<object, object>> GetPropertyGetterLookups(Type objType)
        {
            var key = objType.FullName ?? "";
            if (!PropertyLookupCache.ContainsKey(key))
            {
                var o = objType.GetProperties()
                .Where(p => GetValidations(p).Length != 0)
                .ToDictionary(p => p.Name, CreatePropertyGetter);
                PropertyLookupCache[key] = o;
                return o;
            }
            return (Dictionary<string, Func<object, object>>)PropertyLookupCache[key];
        }
        private static Func<object, object> CreatePropertyGetter(PropertyInfo propertyInfo)
        {
            var instanceParameter = Expression.Parameter(typeof(object), "instance");
            var expression = Expression.Lambda<Func<object, object>>(
                Expression.ConvertChecked(
                    Expression.MakeMemberAccess(
                        Expression.ConvertChecked(instanceParameter, propertyInfo.DeclaringType),
                        propertyInfo),
                    typeof(object)),
                instanceParameter);
            var compiledExpression = expression.Compile();
            return compiledExpression;
        }
        private static ValidationAttribute[] GetValidations(PropertyInfo property)
        {
            return (ValidationAttribute[])property.GetCustomAttributes(typeof(ValidationAttribute), true);
        }
    }
