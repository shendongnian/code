    public class ExampleAttribute : ValidationAttribute
    {
      protected override ValidationResult 
        IsValid(object value, ValidationContext validationContext)
      {
        ICardTypeService service = 
          (ICardTypeService)validationContext.GetService(typeof(ICardTypeService));
      }
    }
