    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        private string _displayName;
     
        public RequiredAttribute()
        {
            ErrorMessageResourceName = "Validation_Required";
        }
     
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            _displayName = validationContext.DisplayName;
            return base.IsValid(value, validationContext);
        }
     
        public override string FormatErrorMessage(string name)
        {
            //LOOK HERE! ;)
            var msg = GetTheTextHereFromYourSource();
            return string.Format(msg, _displayName);
        }
    }
