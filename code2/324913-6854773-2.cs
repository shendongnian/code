    public class Recipe
    {
        [Required]
        [CustomValidation(typeof(AWValidation), "ValidateId", ErrorMessage = "nima")]
        public int Name { get; set; }
    }
    
    public class AWValidation
    {
        public static ValidationResult ValidateId(int ProductID)
        {
            if (ProductID > 2)
            {
                return new ValidationResult("wrong");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            var recipe = new Recipe();
            recipe.Name = 3;
            var context = new ValidationContext(recipe, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
    
            var isValid = Validator.TryValidateObject(recipe, context, results, true);
    
            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }
    }
