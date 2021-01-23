    public class TextBoxEmptyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationResult vr = new ValidationResult(true,null);
            if (string.IsNullOrEmpty(value))
            {
                vr.ErrorContent = " Value can not be null!";
                vr.IsValid = false;
            }
            return vr;
                
        }
    }
