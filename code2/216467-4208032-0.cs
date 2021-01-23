    public class LazyPart<T> : Lazy<T>
    {
        public LazyPart(Func<T> initializer) : base(initializer)
        {
        }
    }
