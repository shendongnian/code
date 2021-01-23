    public interface IWhatever<T>
    {
        List<T> Foo(T BarObject = default(T));
    }
    public class ConcreteWhatever : IWhatever<ConcreteWhatever>
    {
        public List<ConcreteWhatever> Foo(ConcreteWhatever BarObject = default(ConcreteWhatever))
        {
            return null; // replace with proper code
        }
    }
