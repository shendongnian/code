    public class TypeFactory
    {
        public static object Create<T>()
        {
             return new MyInternalType<T>();
        }
    }
