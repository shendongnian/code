    public class Wrapper<T>
    {
        public Wrapper(T wrapped)
        {
            Wrapped = wrapped;
        }
        public T Wrapped { get; set; }
    }
    public class Wrapper
    {
        public static Wrapper<T> Create<T>(T wrapped)
        {
            return new Wrapper<T>(wrapped);
        }
    }
