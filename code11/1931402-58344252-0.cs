    public class Conversion
    {
        private delegate bool Converter(string input, out object output);
        private delegate bool Converter<T>(string input, out T output);
        private Dictionary<Type, Converter> _convertersByType = new Dictionary<Type, Converter>();
        public Conversion()
        {
            AddConverterForTypeAndNullable<short>(short.TryParse);
            AddConverterForTypeAndNullable<int>(int.TryParse);
            AddConverterForTypeAndNullable<decimal>(decimal.TryParse);
            AddConverterForTypeAndNullable<DateTime>(DateTime.TryParse);
        }
        private void AddConverterForTypeAndNullable<T>(Converter<T> converter)
            where T : struct
        {
            _convertersByType.Add(typeof(T), (string input, out object output) =>
            {
                bool result = converter(input, out T typedOutput);
                output = typedOutput;
                return result;
            });
            _convertersByType.Add(typeof(T?), (string input, out object output) =>
            {
                bool result;
                if (string.IsNullOrEmpty(input))
                {
                    result = true;
                    output = null;
                }
                else
                {
                    result = converter(input, out T typedOutput);
                    output = typedOutput;
                }
                return result;
            });
        }
        public object Convert(string value, Type toType)
        {
            object result;
            if (!_convertersByType.TryGetValue(toType, out Converter converter))
            {
                throw new NotSupportedException($"No conversion defined for type: '{toType}'");
            }
            else if (!converter(value, out result))
            {
                throw new Exception($"Value '{value}' cannot be converted to '{toType}'");
            }
            return result;
        }
    }
