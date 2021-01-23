     class Program
        {
            static T convert<T>(string s)
            {
                var typeConverter = TypeDescriptor.GetConverter(typeof(T));
                if (typeConverter != null && typeConverter.CanConvertFrom(typeof(string)))
                {
                    return (T) typeConverter.ConvertFrom(s);
                }
    
                return default(T);
            }
    
            static void Main(string[] args)
            {
                int x = convert<int>( "45");
            }
        }
