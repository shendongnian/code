    public abstract class BaseAbstract
    {
        public abstract int Increment();
    }
    public abstract class AbstractClass<T> where T : BaseAbstract
    {
        private int inc;
        public abstract T Abstract();
        public virtual int Concrete()
        {
            return inc += Abstract().Increment();
        }
    }
