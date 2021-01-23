    public abstract class BaseClass<T>
    {
        public abstract T Type { get; }
    }
    public class Derived : BaseClass<EType>
    {
        public enum EType
        {
            ...
        }
        private EType type;
        public EType Type { get { return type; } }
    }
