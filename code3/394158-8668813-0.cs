    public class ActivationStep2ViewModel : IValidatableObject
    {
     .
     .
     .
     .
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Email != ConfirmEmail)
            {
                 yield return new ValidationResult("The email address you provided does not match the email address in the confirm email box.");
            }
            if(NewPassword != ConfirmPassword)
            {
                 yield return new ValidationResult("The new password you provided does not match the confirmation password in the confirm password box.");
            }
        } 
      
