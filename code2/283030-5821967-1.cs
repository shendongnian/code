    public class User
    {
        public string Name { get; private set; }
        public void SetName(string name, ISpecification<User, string> specification)
        {
            // Insert basic null validation here.
            if (!specification.IsSatisfiedBy(this, name))
            {
                // Throw some validation exception.
            }
            this.Name = name;
        }
    }
    public interface ISpecification<TType, TValue>
    {
        bool IsSatisfiedBy(TType obj, TValue value);
    }
    public class UniqueUserNameSpecification : ISpecification<User, string>
    {
        private IUserRepository repository;
        public UniqueUserNameSpecification(IUserRepository repository)
        {
            this.repository = repository;
        }
        public bool IsSatisfiedBy(User obj, string value)
        {
            if (value == obj.Name)
            {
                return true;
            }
            // Use this.repository for further validation of the name.
        }
    }
