    class AsyncResponseArgs : EventArgs
    {
        public Member Member { get; private set; }
        public AsyncResponseArgs(Member m)
        {
            Member = m;
        }
    }
    
    interface ISomethingApi
    {
        void AuthenticateAsync(string username, string password);
        event EventHandler<AsyncResponseArgs> AuthenticateEnded;
    
        void GetMemberAsync(string username);
        event EventHandler<AsyncResponseArgs> GetMemberEnded;
    }
    
    class BaseHttpClient : ISomethingApi
    {
        protected EventHandlerList Events { get; private set; }
    
        public virtual void AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
        protected static object AuthenticateEndedEvent = new object();
        public event EventHandler<AsyncResponseArgs> AuthenticateEnded
        {
            add { Events.AddHandler(AuthenticateEndedEvent, value); }
            remove { Events.RemoveHandler(AuthenticateEndedEvent, value); }
        }
    
        public virtual void GetMemberAsync(string username)
        {
            throw new NotImplementedException();
        }
        protected static object GetMemberEndedEvent = new object();
        public event EventHandler<AsyncResponseArgs> GetMemberEnded
        {
            add { Events.AddHandler(GetMemberEndedEvent, value); }
            remove { Events.RemoveHandler(GetMemberEndedEvent, value); }
        }
    
        protected void FireEvent(object key, AsyncResponseArgs e)
        {
            EventHandler<AsyncResponseArgs> handler = (EventHandler<AsyncResponseArgs>)Events[key];
            if (handler != null)
                handler(this, e);
        }
    }
    
    class XmlClient : BaseHttpClient
    {
        public override void GetMemberAsync(string username)
        {
            Member member;
            // process here 
            FireEvent(GetMemberEndedEvent, new AsyncResponseArgs(member));
        }
    }
