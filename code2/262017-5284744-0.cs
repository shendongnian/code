    public interface IParser<T>
    {
        T Parse<T>( string item );
    }
    public class KeyValueParser : IParser<KeyValue>
    {
        KeyValuePair Parse<KeyValue>( string item );
    }
    ...
    public class ParserFactory
    {
        public IParser<T> CreateParser<T>()
        {
            var type = typeof(T);
            if (type == typeof(KeyValuePair))
            {
                return new KeyValueParser();
            }
            ...
            throw new InvalidOperationException( "No matching parser type." );
        }
    }
