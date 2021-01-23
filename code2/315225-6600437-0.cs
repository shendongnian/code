    public interface IValidate<T>
    {
        IEnumerable<ValidationError> GetErrors(T instance, string path);
    }
    public sealed class InvariantEntityValidator : IValidate<Entity>
    {
        public IEnumerable<ValidationError> GetErrors(Entity entity, string path)
        {
            //Do simple (invariant) validation...
        }
    }
    public sealed class ComplexEntityValidator : IValidate<Entity>
    {
        public IEnumerable<ValidationError> GetErrors(Entity entity, string path)
        {
            var validator = new InvariantEntityValidator();
            foreach (var error in validator.GetErrors(entity, path))
                yield return error;
            //Do additional validation for this complex case
        }
    }
