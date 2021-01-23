    public class Foo<T>
    {
        public Foo (string input)
    	{
            var typeConverter = TypeDescriptor.GetConverter(typeof(T));
            if (typeConverter.CanConvertFrom(typeof(string)))
            {
                Value = (T)typeConverter.ConvertFromString(input);
            }
            else
            {
                throw new InvalidOperationException();
            }
    	}
        public T Value { get; set;
        }
    }
