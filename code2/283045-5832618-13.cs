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
            return !string.IsNullOrEmpty(subject.Name);
        }
    }
    public class NameNotTakenSpecification : ISpecification<User>
    {
        // omitted code to set service; better use DI
        private Service.IUserNameService UserNameService { get; set; } 
        public bool IsSatisfiedBy(User subject)
        {
            return UserNameService.NameIsAvailable(subject.Name);
        }
    }
