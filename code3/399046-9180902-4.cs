    public interface IRule<in T>{
        bool IsValid(T obj);
        bool WithinScope();
    }
    public interface IValidator<in T>{
        bool IsValid(T obj);
    }
    public interface IRuleFactory<in T>{
        IEnumerable<IRule<T>> BuildRules();
    }
