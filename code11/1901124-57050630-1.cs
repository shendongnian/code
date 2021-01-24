    public abstract class MustInitialize<T>
    {
        public MustInitialize(T parameters)
        {
    
        }
    }
    public class Rule : MustInitialize<IParameters>, IRule
    {
        IParameters _parameters;
    
        public Rule(IParameters parameters)
            : base (parameters)
        {
            _parameters= parameters;
        }
    }
