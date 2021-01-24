    public class MyClass<T> : IEquatable<MyClass<T>>
    {
        private IEqualityComparer<T> comparer;
    
        public MyClass(IEqualityComparer<T> innerComparer = null)
        {
            comparer = innerComparer ?? EqualityComparer<T>.Default;
        }
    
        public T Parameter { get; }
    
        ...
    }
