    public class InjectedSingleton
    {
        public MySession CurrentSession{get;set;}
    
        public void SetSession(string sessionId)
        {
            CurrentSession = GetSessionById(sessionId);
        }
        public void NewSession()
        {
            CurrentSession = new MySession();
        }
    }
    public class DoClass
    {
        private InjectedSingleton inj;
        public DoClass(InjectedSingleton inj)
        {
            this.inj = inj;
        }
        public void OpenNewTab(string sessionId)
        {
            inj.SetSession(sessionId);
        }
        public void JustShowSomething()
        {
            Show(inj.CurrentSession.Id);
        }      
    }
