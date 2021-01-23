    public class EmployeeViewModel
    {
    
        [CustomValidation(typeof(EmployeeViewModel), "ValidateDuplicate")]
        [Required(ErrorMessage = "Username is required")]
        [DisplayName("Username")]
        public string Username { get; set; }
    
        public static ValidationResult ValidateDuplicate(string username)
        {
          bool isValid;
          
          using(var db = new YourContextName) {
            if(db.EmployeeViewModel.Where(e => e.Username.Equals(username)).Count() > 0)
           {
              isValid = false;
           } else {
              isValid = true;
           }
          }
    
          if (isValid)
          {
            return ValidationResult.Success;
          }
          else
          {
            return new ValidationResult("Username already exists");
          }
    
        }
    }
