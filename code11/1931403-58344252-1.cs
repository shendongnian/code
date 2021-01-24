    public delegate bool Parser<T>(string input, out T output);
    public class Parsers
    {
        private delegate bool UntypedParser(string input, out object output);
        private Dictionary<Type, UntypedParser> _parsersByType = new Dictionary<Type, UntypedParser>();
        /// <summary>
        /// Creates a <see cref="Parsers"/> instance pre-populated with parsers for the most common types.
        /// </summary>
        public static Parsers CreateDefault()
        {
            Parsers result = new Parsers();
            result.AddParser<string>((string input, out string output) => { output = input; return true; });
            result.AddParserForNullable<bool>(bool.TryParse);
            result.AddParserForNullable<byte>(byte.TryParse);
            result.AddParserForNullable<DateTime>(DateTime.TryParse);
            result.AddParserForNullable<decimal>(decimal.TryParse);
            result.AddParserForNullable<double>(double.TryParse);
            result.AddParserForNullable<float>(float.TryParse);
            result.AddParserForNullable<int>(int.TryParse);
            result.AddParserForNullable<short>(short.TryParse);
            return result;
        }
        /// <summary>
        /// Registers a parser for the given type T
        /// </summary>
        public void AddParser<T>(Parser<T> parser)
        {
            _parsersByType[typeof(T)] = (string input, out object output) => ParseObject(parser, input, out output);
        }
        /// <summary>
        /// Registers a parser for the given type T as well as <see cref="Nullable{T}"/>
        /// </summary>
        public void AddParserForNullable<T>(Parser<T> parser)
            where T : struct
        {
            _parsersByType[typeof(T)] = (string input, out object output) => ParseObject(parser, input, out output);
            _parsersByType[typeof(T?)] = (string input, out object output) => ParseNullable(parser, input, out output);
        }
        /// <summary>
        /// For nullable types, return null when the input is an empty string or null.
        /// </summary>
        /// <remarks>This is not called for the string-parser. Meaning an empty string is not parsed into a null value.</remarks>
        private bool ParseNullable<T>(Parser<T> parser, string input, out object output)
            where T : struct
        {
            bool result;
            if (string.IsNullOrEmpty(input))
            {
                result = true;
                output = null;
            }
            else
            {
                result = ParseObject(parser, input, out output);
            }
            return result;
        }
        /// <summary>
        /// Helper method to convert the typed output into an object (possibly boxing the value)
        /// </summary>
        private bool ParseObject<T>(Parser<T> parser, string input, out object output)
        {
            bool result = parser(input, out T typedOutput);
            output = typedOutput;
            return result;
        }
        /// <summary>
        /// Finds the parser for the given target type and uses it to parse the input.
        /// </summary>
        public object Parse<T>(string input)
        {
            Type targetType = typeof(T);
            object result;
            if (!_parsersByType.TryGetValue(targetType, out UntypedParser parser))
            {
                throw new ArgumentException($"No parser defined for type '{targetType}'.");
            }
            else if (!parser(input, out result))
            {
                throw new ArgumentException($"Cannot parse '{targetType}' from  input '{input}'.");
            }
            return result;
        }
    }
