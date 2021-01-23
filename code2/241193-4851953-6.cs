    public sealed class ProductValidator : IValidator<Product>
    {
        protected override IEnumerable<ValidationResult> Validate(
            Product entity)
        {
            if (entity.Name.Trim().Length == 0)
                yield return new ValidationResult("Name", 
                    "Name is required.");
            
            if (entity.Description.Trim().Length == 0)
                yield return new ValidationResult("Description",
                    "Description is required.");
            
            if (entity.UnitsInStock < 0)
                yield return new ValidationResult("UnitsInStock", 
                    "Units in stock cnnot be less than zero.");
        }
    }
