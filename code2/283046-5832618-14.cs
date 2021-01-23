    public class UserPersistenceValidator : IValidator<User>
    {
        private readonly IList<ISpecification<User>> Rules =
            new List<ISpecification<User>>
                {
                    new IdNotEmptySpecification(),
                    new NameNotEmptySpecification(),
                    new NameNotTakenSpecification()
                    // and more ... better use DI to fill this list
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
