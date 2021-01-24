    using System.ComponentModel.DataAnnotations;
    class Driver
    {
    
    public static void Main(string[] args)
    {
                var results = new List<ValidationResult>();
                var vc = new ValidationContext(AreaDataRow, null, null);
                var errorMessages = new List<string>();
    
                if (!Validator.TryValidateObject(AreaDataRow, vc, results, true))
                {
                    foreach (ValidationResult result in results)
                    {
                        if (!string.IsNullOrEmpty(result.ErrorMessage))
                        {
                            errorMessages.Add(result.ErrorMessage);
                        }
                    }
    
                    isError = true;
                }
    }
    }
