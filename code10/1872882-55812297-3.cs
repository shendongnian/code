    public class MyException : AggregateException
    {
    
        public MyException(string message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions)
        {
        }
    }
