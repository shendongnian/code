            public class TestClass<T>
            {
                public T Cast(object o)
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(o);
                    if (converter.CanConvertTo(typeof(T)))
                    {
                       var result = converter.ConvertTo(o, typeof(T));
                       return (T)result;
                    }
                    throw new InvalidCastException(
                          string.Format("Cannot convert from {0} to {1}", o.GetType().Name, typeof(T).Name));
                }
            }
