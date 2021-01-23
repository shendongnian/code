    public class ClientBase<S> where S : class, new()
    {
        protected S CreateObject()
        {
            return new S();
        }
    }
