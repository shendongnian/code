    public interface ISessionContext
    {
        object this[string propertyName] { get; set; }
    }
    public class ServerContext : ISessionContext
    {
        public object this[string propertyName]
        {
            get { return HttpContext.Current.Session[propertyName]; }
            set { HttpContext.Current.Session[propertyName] = value; }
        }
    }
    public class SomeClassThatUsesSessionState
    {
        private readonly ISessionContext sessionContext;
        public SomeClassThatUsesSessionState(ISessionContext sessionContext)
        {
            this.sessionContext = sessionContext;
        }
        public void SomeMethodThatUsesSessionState()
        {
            string somevar = (string)sessionContext["somevar"];
            // todo: do something with somevar
        }
    }
