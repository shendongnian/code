    public sealed class ProductValidator : Validator<Product>
    {
        protected override IEnumerable<ValidationResult> Validate(
            Product entity)
        {
            if (entity.Name.Trim().Length == 0)
                yield return new ValidationResult(
                    nameof(Product.Name), "Name is required.");
            
            if (entity.Description.Trim().Length == 0)
                yield return new ValidationResult(
                    nameof(Product.Description), "Description is required.");
            
            if (entity.UnitsInStock < 0)
                yield return new ValidationResult(
                    nameof(Product.UnitsInStock), 
                    "Units in stock cnnot be less than zero.");
        }
    }
