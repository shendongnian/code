    public interface ISessionWrapper
    {
        void DoSomethingWithSession();
    }
    public sealed class SessionWrapper : MarshalByRefObject, ISessionWrapper
    {
        private readonly Session _session;
        public SessionWrapper(Session session)
        {
            _session = session;
        }
        public void DoSomethingWithSession()
        {
            //Do something with the wrapped session...
            //This executes inside the sandbox, even though it can be called (via proxy) from outside the sandbox
        }
    }
