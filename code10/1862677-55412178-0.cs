    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string password = value.ToString();
            var errorMessage = "";
            if (password.Length < 8)
            {
                errorMessage += "Password must contain at least 8 characters.";             
            }
            if (password.Count(c => char.IsLower(c)) == 0)
            {
                errorMessage += "Password must contain a lowercase character.";
            }
            //other rules
            if(String.IsNullOrEmpty(errorMessage))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(errorMessage);
            }
        }
