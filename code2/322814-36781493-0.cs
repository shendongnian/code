    public class RegisterViewModel : IValidatableObject
    {
        /// <summary>
        /// Error message for Minimum password
        /// </summary>
        public static string PasswordLengthErrorMessage => $"The password must be at least {PasswordMinimumLength} characters";
        /// <summary>
        /// Minimum acceptable password length
        /// </summary>
        public const int PasswordMinimumLength = 8;
        /// <summary>
        /// Gets or sets the password provided by the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        /// <summary>
        /// Only need to validate the minimum length
        /// </summary>
        /// <param name="validationContext">ValidationContext, ignored</param>
        /// <returns>List of validation errors</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errorList = new List<ValidationResult>();
            if ((Password?.Length ?? 0 ) < PasswordMinimumLength)
            {
                errorList.Add(new ValidationResult(PasswordLengthErrorMessage, new List<string>() {"Password"}));
            }
            return errorList;
        }
    }
