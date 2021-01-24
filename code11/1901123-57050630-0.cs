    public abstract class MustInitialize<T>
    {
        public MustInitialize(T parameters)
        {
    
        }
    }
    public class Rule : MustInitialize<IParameters>, IRule
    {
        IParameters _parameters;
    
        public Drawable(IParameters parameters)
            : base (parameters)
        {
            _parameters= parameters;
        }
    }
