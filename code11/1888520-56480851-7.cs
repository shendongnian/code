    public class Server : MonoBehaviour
    {
        private static readonly List<IServerCommunicationHandler> CommunicationListeners = new List<IServerCommunicationHandler>();
        private static readonly List<IServerSceneSyncHandler> SceneSyncListeners = new List<IServerSceneSyncHandler>();
    
        public static void AddCommunicationListener(IServerCommunicationHandler listener)
        {
            if (!CommunicationListeners.Contains(listener)) CommunicationListeners.Add(listener);
        }
    
        public static void RemoveCommunicationListener(IServerCommunicationHandler listener)
        {
            if (CommunicationListeners.Contains(listener)) CommunicationListeners.Remove(listener);
        }
    
        public static void AddSceneSyncListener(IServerSceneSyncHandler listener)
        {
            if (!SceneSyncListeners.Contains(listener)) SceneSyncListeners.Add(listener);
        }
    
        public static void RemoveSceneSyncListener(IServerSceneSyncHandler listener)
        {
            if (SceneSyncListeners.Contains(listener)) SceneSyncListeners.Remove(listener);
        }
    }
    
