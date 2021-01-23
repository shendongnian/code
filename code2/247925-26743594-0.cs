    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class EvaluateRegexIfPropEqualsValue : ValidationAttribute
    {
        Regex _regex;
        string _prop;
        object _targetValue;
        public EvaluateRegexIfPropEqualsValue(string regex, string prop, object value)
        {
            this._regex = new Regex(regex);
            this._prop = prop;
            this._targetValue = value;
        }
        bool PropertyContainsValue(Object obj)
        {
            var propertyInfo = obj.GetType().GetProperty(this._prop);
            return (propertyInfo != null && this._targetValue.Equals(propertyInfo.GetValue(obj, null)));
        }
        protected override ValidationResult IsValid(object value, ValidationContext obj)
        {
            if (this.PropertyContainsValue(obj.ObjectInstance) && !this._regex.IsMatch(value.ToString()))
            {
                return new ValidationResult(this.ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
