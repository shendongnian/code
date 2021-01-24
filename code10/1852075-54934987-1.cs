     public class RequiredIfYesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var radioName = validationContext.ObjectInstance.GetType().GetProperty("Subscribe");
            string radioValue = radioName.GetValue(validationContext.ObjectInstance, null).ToString();
            var emailName = validationContext.ObjectInstance.GetType().GetProperty("Email");
            string emailValue = emailName.GetValue(validationContext.ObjectInstance, null).ToString();
            if (radioValue == "Yes" && string.IsNullOrEmpty(emailValue))
            {
                return new ValidationResult("Email is Required.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
