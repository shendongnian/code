     [Serializable()]
        public class CustomCmdLineHost : ITextTemplatingEngineHost,ITextTemplatingSessionHost
        {
    
            ITextTemplatingSession session = new TextTemplatingSession();
    
            public ITextTemplatingSession CreateSession()
            {
                return session;
            }
    
            public ITextTemplatingSession Session
            {
                get
                {
                    return session;
                }
                set
                {
                    session = value;
                }
            }
