    public class CheckExtension : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var document = value as Document;
            var extension = Path.GetExtension(document.FormFile.FileName);
            // TODO
            return ValidationResult.Success;
        }
    }
