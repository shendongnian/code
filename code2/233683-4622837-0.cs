    public class BytesProvider<T> : IBytesProvider<T>
    {
        public static BytesProvider<T> Default
        {
            get { return DefaultBytesProviders.GetDefaultProvider<T>(); }
        }
        Func<T, byte[]> _conversion;
    
        internal BytesProvider(Func<T, byte[]> conversion)
        {
            _conversion = conversion;
        }
    
        public byte[] GetBytes(T value)
        {
            return _conversion(value);
        }
    }
    
    static class DefaultBytesProviders
    {
        static Dictionary<Type, object> _providers;
    
        static DefaultBytesProviders()
        {
            // Here are a couple for illustration. Yes, I am suggesting that
            // in reality you would add a BytesProvider<T> for each T
            // supported by the BitConverter class.
            _providers = new Dictionary<Type, object>
            {
                { typeof(int), new BytesProvider<int>(BitConverter.GetBytes) },
                { typeof(long), new BytesProvider<long>(BitConverter.GetBytes) }
            };
        }
    
        public static BytesProvider<T> GetDefaultProvider<T>()
        {
            return (BytesProvider<T>)_providers[typeof(T)];
        }
    }
