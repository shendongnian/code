    public class ClientBase<S> where S : new()
    {
        protected S CreateObject()
        {
            return new S();
        }
    }
