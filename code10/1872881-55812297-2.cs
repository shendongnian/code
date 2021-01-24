    public class MyException : Exception
    {
        private readonly ReadOnlyCollection<Exception> _innerExceptions;
    
        public MyException(string message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions.FirstOrDefault())
        {
            _innerExceptions = innerExceptions.ToList().AsReadOnly();
        }
    
        public ReadOnlyCollection<Exception> InnerExceptions => _innerExceptions;
    }
