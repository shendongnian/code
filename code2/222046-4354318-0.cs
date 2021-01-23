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
    
    class BaseHttpClient : Component, ISomethingApi
    {
        public virtual void AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
        protected static object AuthenticateEndedEvent = new object();
        public event EventHandler<AsyncResponseArgs> AuthenticateEnded
        {
            add { base.Events.AddHandler(AuthenticateEndedEvent, value); }
            remove { base.Events.RemoveHandler(AuthenticateEndedEvent, value); }
        }
    
        public virtual void GetMemberAsync(string username)
        {
            throw new NotImplementedException();
        }
        protected static object GetMemberEndedEvent = new object();
        public event EventHandler<AsyncResponseArgs> GetMemberEnded
        {
            add { base.Events.AddHandler(GetMemberEndedEvent, value); }
            remove { base.Events.RemoveHandler(GetMemberEndedEvent, value); }
        }
    
        protected void FireEvent(object key, AsyncResponseArgs e)
        {
            EventHandler<AsyncResponseArgs> handler = (EventHandler<AsyncResponseArgs>)base.Events[key];
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
