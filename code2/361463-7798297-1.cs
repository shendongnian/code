    public abstract class Base<T> where T : Base<T>
    {
        public T Method()
        {
            return (T) (object) this;
        }
    }
    public class Derived1 : Base<Derived1>
    {
    }
