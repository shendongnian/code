    public class IsValidZipCode: ValidationAttribute
    {
       public override bool IsValid(object value)
       {
          return db.ValidateSomething(value);
       }
    }
