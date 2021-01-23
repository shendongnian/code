    public class ConstraintViolation
    {
        public ConstraintViolation(IConstraintBase source, string description)
        {
            Source = source;
            Description = description;
        }
        public IConstraintBase Source { get; }
        public string Description { get; set; }
    }
    public interface IConstraintBase
    {
        public string Name { get; }
        public string Description { get; }
    }
    public interface IConstraint<T> : IConstraintBase
    {
        public IEnumerable<ConstraintViolation> GetViolations(T value);
    }
