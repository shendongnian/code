    public class MyException : AggregateException
    {
        private readonly ReadOnlyCollection<Exception> _innerExceptions;
    
        public MyException(string message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions)
        {
        }
    }
