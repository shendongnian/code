    public class MiejsceWykonaniaNadgodzinTextRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //example test
            if(value.ToString() == "aaa")
                return new ValidationResult(false, $"Error: value = aaa");
            return ValidationResult.ValidResult;
        }
    }
