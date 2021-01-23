    public class Validator<T> where T : CoreObjectBase<T>
    {
        public ValidationResponse Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(entity, null, null);
            var isValid = Validator.TryValidateObject(entity, context, validationResults);
            return new ValidationResponse(validationResults.ToArray());
        }
    }
