    // define a non-generic parser interface so that we can refer to all types of parsers
    public interface IParser
    {
        object Read(BinaryReader reader);
    }
    // define a generic parser interface so that we can specify a Read method specific to a particular type
    public interface IParser<T> : IParser
    {
        new T Read(BinaryReader reader);
    }
    public abstract class Parser<T> : IParser<T>
    {
        public abstract T Read(BinaryReader reader);
        object IParser.Read(BinaryReader reader)
        {
            return this.Read(reader);
        }
    }
    // define a Parser attribute so that we can easily determine the correct parser for a given type
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class ParserAttribute : Attribute
    {
        public Type ParserType { get; private set; }
        public ParserAttribute(Type parserType)
        {
            if (!typeof(IParser).IsAssignableFrom(parserType))
                throw new ArgumentException(string.Format("The type [{0}] does not implement the IParser interface.", parserType.Name), "parserType");
            this.ParserType = parserType;
        }
        public ParserAttribute(Type parserType, Type targetType)
        {
            // check that the type represented by parserType implements the IParser interface
            if (!typeof(IParser).IsAssignableFrom(parserType))
                throw new ArgumentException(string.Format("The type [{0}] does not implement the IParser interface.", parserType.Name), "parserType");
            // check that the type represented by parserType implements the IParser<T> interface, where T is the type specified by targetType
            if (!typeof(IParser<>).MakeGenericType(targetType).IsAssignableFrom(parserType))
                throw new ArgumentException(string.Format("The type [{0}] does not implement the IParser<{1}> interface.", parserType.Name, targetType.Name), "parserType");
            this.ParserType = parserType;
        }
    }
    // let's define a couple of example classes for parsing
    // the MyObjectA class corresponds to ParseObject1 in the original question
    [Parser(typeof(MyObjectAParser))] // the parser type for MyObjectA is MyObjectAParser
    class MyObjectA
    {
        // ...
    }
    // the MyObjectB class corresponds to ParseObject2 in the original question
    [Parser(typeof(MyObjectAParser))] // the parser type for MyObjectB is MyObjectBParser
    class MyObjectB
    {
        // ...
    }
    // a static class that contains helper functions to handle parsing logic
    static class ParseHelper
    {
        public static MyObjectA ReadObjectA(BinaryReader reader)
        {
            // <code here to parse MyObjectA from BinaryReader>
            throw new NotImplementedException();
        }
        public static MyObjectB ReadObjectB(BinaryReader reader)
        {
            // <code here to parse MyObjectB from BinaryReader>
            throw new NotImplementedException();
        }
    }
    // a parser class that parses objects of type MyObjectA from a BinaryReader
    class MyObjectAParser : Parser<MyObjectA>
    {
        public override MyObjectA Read(BinaryReader reader)
        {
            return ParseHelper.ReadObjectA(reader);
        }
    }
    // a parser class that parses objects of type MyObjectB from a BinaryReader
    class MyObjectBParser : Parser<MyObjectB>
    {
        public override MyObjectB Read(BinaryReader reader)
        {
            return ParseHelper.ReadObjectB(reader);
        }
    }
    // define a ParserRepository to encapsulate the logic for finding the correct parser for a given type
    public class ParserRepository
    {
        private Dictionary<Type, IParser> _Parsers = new Dictionary<Type, IParser>();
        public IParser<T> GetParser<T>()
        {
            // attempt to look up the correct parser for type T from the dictionary
            Type targetType = typeof(T);
            IParser parser;
            if (!this._Parsers.TryGetValue(targetType, out parser))
            {
                // no parser was found, so check the target type for a Parser attribute
                object[] attributes = targetType.GetCustomAttributes(typeof(ParserAttribute), true);
                if (attributes != null && attributes.Length > 0)
                {
                    ParserAttribute parserAttribute = (ParserAttribute)attributes[0];
                    // create an instance of the identified parser
                    parser = (IParser<T>)Activator.CreateInstance(parserAttribute.ParserType);
                    // and add it to the dictionary
                    this._Parsers.Add(targetType, parser);
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Unable to find a parser for the type [{0}].", targetType.Name));
                }
            }
            return (IParser<T>)parser;
        }
        // this method can be used to set up parsers without the use of the Parser attribute
        public void RegisterParser<T>(IParser<T> parser)
        {
            this._Parsers[typeof(T)] = parser;
        }
    }
