     public class ImageCheckAttribute : ValidationAttribute
        {
            
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
              
                try
                {
                    using (MemoryStream ms = new MemoryStream((byte[])value))
                        Image.FromStream(ms);
                }
                catch (ArgumentException)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
                return null;
            }
        }
