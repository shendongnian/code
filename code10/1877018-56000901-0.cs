    public class FileAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            FileModel fileModel = (FileModel)validationContext.ObjectInstance;
            if (fileModel.FileID ==0)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return "You didn't select a file to upload";
        }
    }
