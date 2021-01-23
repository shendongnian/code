    public class UserPersistenceValidator : IValidator<User>
    {
        private readonly IList<ISpecification<User>> Rules =
            new List<ISpecification<User>>
                {
                    new IdNotEmptySpecification(),
                    new NameNotEmptySpecification(),
                    // and more ...
                };
        public bool IsValid(User entity)
        {
            return BrokenRules(entity).Count() > 0;
        }
        public IEnumerable<string> BrokenRules(User entity)
        {
            return Rules.Where(rule => !rule.IsSatisfiedBy(entity))
                        .Select(rule => GetMessageForBrokenRule(rule));
        }
        // ...
    }
