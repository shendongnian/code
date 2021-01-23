    public class BasicIntegerValidator : ValidationRule {       
        
        public string PropertyNameToDisplay { get; set; }
        public bool Nullable { get; set; }
        public bool AllowNegative { get; set; }
        string PropertyNameHelper { get { return PropertyNameToDisplay == null ? string.Empty : " for " + PropertyNameToDisplay; } }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo) {
            string textEntered = (string)value;
            int intOutput;
            double junkd;
            if (String.IsNullOrEmpty(textEntered))
                return Nullable ? new ValidationResult(true, null) : new ValidationResult(false, getMsgDisplay("Please enter a value"));
            if (!Int32.TryParse(textEntered, out intOutput))
                if (Double.TryParse(textEntered, out junkd))
                    return new ValidationResult(false, getMsgDisplay("Please enter a whole number (no decimals)"));
                else
                    return new ValidationResult(false, getMsgDisplay("Please enter a whole number"));
            else if (intOutput < 0 && !AllowNegative)
                return new ValidationResult(false, getNegativeNumberError());
            return new ValidationResult(true, null);
        }
        private string getNegativeNumberError() {
            return PropertyNameToDisplay == null ? "This property must be a positive, whole number" : PropertyNameToDisplay + " must be a positive, whole number";
        }
        private string getMsgDisplay(string messageBase) {
            return String.Format("{0}{1}", messageBase, PropertyNameHelper);
        }
    }
