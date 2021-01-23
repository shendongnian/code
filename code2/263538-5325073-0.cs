            public class TestClass<T> where T: struct
            {
                public T Cast(object o)
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(o);
                    var result = converter.ConvertTo(o,typeof(T));
                    return (T)result;
                }
            }
