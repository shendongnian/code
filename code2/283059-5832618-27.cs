    public interface IValidator<T>
    {
        bool IsValid(T entity);
        IEnumerable<string> BrokenRules(T entity);
    }
    
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T subject);
    }
