    [Serializable]
    public class FooException : Exception
    {
        // Logger configured for email, file, etc.
        static ILog _log = LogFactory.Create();
        public FooException(string message, Exception innerException)
            : base(message, innerException)
        {
            _log.Error(message, innerException);
        }
        // ...
    }
 
    public class FooDataAccess<T> : IFooRepository
    {
        public T GetFoo()
        {
            // Consider creating general helper methods with 
            // Action, Func, parameters so that you only have
            // to code the try ... catch block once.
            try
            {              
                // all exceptions caught
            }
            catch (Exception e)
            {
                throw new FooException(Exceptions.GetFooException, e);
            }
        }     
    }
