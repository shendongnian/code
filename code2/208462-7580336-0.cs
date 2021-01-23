        public abstract class ModelReader
        {
            private List<ParseError> _errors = new List<ParseError>();
            private bool _throwOnError;
            public ModelReader()
               :this(true)
            {
            }
            public ModelReader(bool throwOnError)
            {
               _throwOnError = throwOnError;
            }
            // use AddError in implementation when an error is detected
            public abstract Model Read();
            public virtual IEnumerable<ParseError> Errors
            {
               get {return _errors;}
            }
        
            protected virtual void AddError(ParseError error)
            {
               if (_throwOnError) // fail fast?
                  throw new ParseException(error);
               _errors.Add(error);
            }
        }
        
        public class ParseError
        {
            public ParseError(...)
            {
            }
        
            public ParseErrorCode Code { get; private set; }
            public int Line { get; private set; }
            public int LinePosition { get; private set; }
            public string Reason { get; private set; }
            public string SourceText { get; private set; }
            public int StreamPosition { get; private set; }
        }
    
        public enum ParseErrorCode
        {
           InvalidSyntax,
           ClosingQuoteNotFound,
           ... whatever...
        }
        public class ParseException: Exception
        {
            ...
        }
