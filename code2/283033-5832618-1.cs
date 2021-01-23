    public class IdNotEmptySpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User subject)
        {
            return !string.IsNullOrEmpty(subject.Id);
        }
    }
    public class NameNotEmptySpecification : ISpecification<User>
    {
        public bool IsSatisfiedBy(User subject)
        {
            return !string.IsNullOrEmpty(subject.Id);
        }
    }
