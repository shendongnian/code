    public interface IFoo
    {
        void Set(string value);
    }
    public class Foo<T> : IFoo
    {
        private T val;
        public void Set(string value)
        {
            var typeConverter = TypeDescriptor.GetConverter(typeof(T));
            if(typeConverter.CanConvertFrom(typeof(string)))
            {
                val = (T)typeConverter.ConvertFromString(value);
            }
            else 
            {
                throw new InvalidOperationException();
            }
        }
    }
