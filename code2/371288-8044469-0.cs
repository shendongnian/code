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
    public class StringLengthConstraint : IConstraint<string>
    {
        public LengthConstraint(int maximumLength)
            : this(minimumLength: 0, maximumLength: maximumLength)
        {
        }
        public LengthConstraint(int minimumLength, int maximumLength,
            bool isNullAllowed = false)
        {
            MinimumLength = minimumLength;
            MaximumLength = maximumLengthh;
            IsNullAllowed = isNullAllowed;
        }
        public int MinimumLength { get; private set; }
        public int MaximumLength { get; private set; }
        public bool IsNullAllowed { get; private set; }
        public IEnumerable<ConstraintViolation> GetViolations(string value)
        {
            if(value == null)
            {
                if(!IsNullAllowed)
                {
                    yield return CreateViolation("Value cannot be null");
                }
            }
            else
            {
                int length = value.Length;
                if(length < MinimumLength)
                {
                    yield return CreateViolation("Value is shorter than minimum length {0}",
                        MinimumLength);
                }
                if(length > MaximumLength)
                {
                    yield return CreateViolation("Value is longer than maximum length {0}",
                        MaximumLength);
                }
            }
        }
        public string Name { return "String Length"; }
        public string Description
        {
            return string.Format("Ensure a string is an acceptable length"
                + " - Minimum: {0}"
                + " - Maximum: {1}"
                + "{2}"
                , MinimumLength
                , MaximumLength
                , IsNullAllowed ? "" : ", and is not null"
                );
        }
        private ConstraintViolation CreateViolation(string description,
            params object[] args)
        {
            return new ConstraintViolation(this, string.Format(description, args));
        }
    }
