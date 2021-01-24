    public class Example : MonoBehaviour, IServerCommunicationHandler, IServerSceneSyncHandler
    {
        private void Awake()
        {
            Server.AddCommunicationListener(this);
            Server.AddSceneSyncListener(this);
        }
    
        private void OnDestroy()
        {
            Server.RemoveCommunicationListener(this);
            Server.RemoveSceneSyncListener(this);
        }
    
        public void OnSeverCommunication()
        {
            Debug.Log("Communication was invoked", this);
        }
    
        public void OnServerSceneSync()
        {
            Debug.Log("Scene sync was invoked", this);
        }
    }
