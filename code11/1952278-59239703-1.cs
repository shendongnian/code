    internal class IllogicalCallContext
    {
        private Hashtable m_Datastore;
        private Object m_HostContext;
 
        internal struct Reader
        {
            IllogicalCallContext m_ctx;
 
            public Reader(IllogicalCallContext ctx) { m_ctx = ctx; }
 
            public bool IsNull { get { return m_ctx == null; } }
 
            [System.Security.SecurityCritical]
            public Object GetData(String name) { return IsNull ? null : m_ctx.GetData(name); }
 
            public Object HostContext { get { return IsNull ? null : m_ctx.HostContext; } }
        }
 
        private Hashtable Datastore
        {
            get 
            { 
                if (null == m_Datastore)
                {
                    // The local store has not yet been created for this thread.
                    m_Datastore = new Hashtable();
                }
                return m_Datastore;
            }
        }
        
        internal Object HostContext
        {
            get
            {
                return m_HostContext;
            }
            set
            {
                m_HostContext = value;
            }
        }
 
            public Object HostContext { get { return IsNull ? null : m_ctx.HostContext; } }
        }
