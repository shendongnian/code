    {
        Errors error = Errors.Access;
        var handler = error.GetHandler();   
    }
    public abstract class ErrorHandler { }
    public class AccessHandler : ErrorHandler { }
    public class ConnectionHandler : ErrorHandler { }
    public class OtherHandler : ErrorHandler { }
    public interface CoHandler<T>
        where T : ErrorHandler
    {
        T GetHandler();
    }
    public abstract class Errors
    {
        public static Errors Access = new AccessError();
        public static Errors Connection = new ConnectionError();
        public abstract ErrorHandler GetHandler();
        private class AccessError : Errors, CoHandler<AccessHandler>
        {
            public override ErrorHandler GetHandler()
            {
                return new AccessHandler();
            }
            AccessHandler CoHandler<AccessHandler>.GetHandler()
            {
                return new AccessHandler();
            }
        }
        private class ConnectionError : Errors, CoHandler<ConnectionHandler>
        {
            public override ErrorHandler GetHandler()
            {
                return new ConnectionHandler();
            }
            ConnectionHandler CoHandler<ConnectionHandler>.GetHandler()
            {
                return new ConnectionHandler();
            }
        }
        
    }
