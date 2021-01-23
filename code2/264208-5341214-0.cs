    public class ConverterThingy
    {
        public T Convert<T>(object o)
            where T : class
        {
            return o as T;
        }
    }
