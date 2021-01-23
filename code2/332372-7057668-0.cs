    public class Dog : Animal
    {
      public override IEnumerable<ValidationResult> Validate(ValidationContext      validationContext)
      {
         foreach(var result in base.Validate(validationContext))
         {
         }
         
         //dog specific validation follows here...
      }
    }
