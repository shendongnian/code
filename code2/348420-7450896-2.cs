    public class Converter<T>
    {
        T _source;
        internal Converter(T source)
        {
            _source = source;
        }
        public T2 To<T2>()
        {
            return Ext.Convert<T, T2>(_source);
        }
    }
