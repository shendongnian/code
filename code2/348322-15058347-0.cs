    protected override ValidationResult IsValid(Object value, ValidationContext     validationContext) {
    
       if (ShouldICareAboutYou(validationContext.MemberName))
       {
           //Do some stuff
       }
   
       return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), new string[] { validationContext.MemberName });
    }
