    public class User
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailIsRequired")]
        public string EmailAddress { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var value = "test@test.com";
    
            var context = new ValidationContext(value, null, null);        
            var results = new List<ValidationResult>();
            var attributes = typeof(User)
                .GetProperty("EmailAddress")
                .GetCustomAttributes(false)
                .OfType<ValidationAttribute>()
                .ToArray();
    
            if (!Validator.TryValidateValue(value, context, results, attributes))
            {
                foreach (var result in results)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("{0} is valid", value);
            }
        }
    }
