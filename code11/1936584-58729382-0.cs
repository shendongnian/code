    public class MyTest
    {
        public MyTest(string sessionId, string identityName, bool allowSomething, string filePath)
        {
            SessionId = sessionId;
            IdentityName = identityName;
            AllowSomething = allowSomething;
            FilePath = filePath;
        }
    
        public string SessionId { get; }
        public string IdentityName { get; }
        public bool AllowSomething { get; }
        public string FilePath { get; }
    
        public void SaveSomething(string message)
        {
            Save($"{SessionId} == {IdentityName} == {message}");
            if (allowSomething))
                DoSomethingElse();
        }
    
        private void Save(message)
        {
            var filePath = FilePath;
            // some code here to save
        }
    
        private void DoSomethingElse()
        {
            // some code here
        }
    }
