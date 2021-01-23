    public class DayTotalAttribute : ValidationAttribute
    {
        ProjectDBContext db = new ProjectDBContext();
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return false;
            }
            var model = (SomeClass)validationContext.ObjectInstance;
            var products = from p in db.EmployeeDayMax
                           where p.EmployeeId = model.EmployeeId
            bool somethingIsWrong = // do your validation here
            if (somethingIsWrong)
                 return ValidationResult("Error Message");
            return base.IsValid(value, validationContext);
        }    
    }
