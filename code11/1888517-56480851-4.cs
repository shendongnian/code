    public class Example : MonoBehaviour, IServerCommunicationHandler, IServerSceneSyncHandler
    {
        private void Awake()
        {
            Server.AddCommunicationListener(this);
            Server.RemoveSceneSyncListener((IServerSceneSyncHandler) this);
        }
    
        private void OnDestroy()
        {
            Server.RemoveCommunicationListener(this);
            Server.RemoveSceneSyncListener((IServerCommunicationHandler) this);
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
