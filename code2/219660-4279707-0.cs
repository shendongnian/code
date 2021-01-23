    abstract class BaseClass<T>
    {
        public abstract T Type { get; }
    }
    class Derived : BaseClass<EType>
    {    
        public enum EType
        {
            type1,
            type2
        }
        private EType _type;
        public override EType Type { get { return _type; } }
    }
 
