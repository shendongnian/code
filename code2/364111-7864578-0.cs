    public class GreaterThanAttribute : ValidationAttribute
    {
        public GreaterThanAttribute(string otherProperty)
            :base("{0} must be greater than {1}")
        {
            OtherProperty = otherProperty;
        }
    
        public string OtherProperty { get; set; }
    
        public override string FormatErrorMessage(string name)
        {            
            return string.Format(ErrorMessageString, name, OtherProperty);
        }
    
        protected override ValidationResult 
            IsValid(object firstValue, ValidationContext validationContext)
        {
            var firstComparable = firstValue as IComparable;
            var secondComparable = GetSecondComparable(validationContext);
    
            if (firstComparable != null && secondComparable != null)
            {
                if (firstComparable.CompareTo(secondComparable) < 1)
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }               
    
            return ValidationResult.Success;
        }        
    
        protected IComparable GetSecondComparable(
            ValidationContext validationContext)
        {
            var propertyInfo = validationContext
                                  .ObjectType
                                  .GetProperty(OtherProperty);
            if (propertyInfo != null)
            {
                var secondValue = propertyInfo.GetValue(
                    validationContext.ObjectInstance, null);
                return secondValue as IComparable;
            }
            return null;
        }
    }
