    public class ServerListener : IServerListener
    {
        void IServerListener.onServerStarted() => OnServerStarted?.Invoke();
        void IServerListener.onSessionStarted() => OnSessionStarted?.Invoke();
        void IServerListener.onSessionCompleted(List<string> data) => OnSessionCompleted?.Invoke(data);
        public Action OnServerStarted { get; set; }
    
        public Action<List<string>> OnSessionCompleted { get; set; }
    
        public Action OnSessionStarted { get; set; }
    }
