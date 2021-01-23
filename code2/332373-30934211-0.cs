    public class Dog : Animal
    {
      public override IEnumerable<ValidationResult> Validate(ValidationContext      validationContext)
      {
         foreach(var result in base.Validate(validationContext).ToList())
         {
         }
    
         //dog specific validation follows here...
      }
    }
