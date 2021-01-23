    public interface IAction
    {
    }
    public abstract class AbstractParent
    {
        public abstract IAction Action { get; set; }
    }
    public abstract class GenericBase<T> : AbstractParent where T : IAction
    {
        protected IAction _action;
        public override IAction Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }
    }
