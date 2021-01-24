    public class Example : MonoBehaviour
    {
         private void Awake()
         {
             // Note: It is always save to remove callbacks
             //       even if not added yet.
             //       This makes sure they are added only once for this instance
             OnCommunication -= OnServerCommunication;
             OnSceneSync -= OnServerSceneSync;
             OnCommunication += OnServerCommunication;
             OnSceneSync += OnServerSceneSync;
         }
         privtae void OnDestroy()
         {
             // Make sure to always remove callbacks when not needed anymore
             OnCommunication -= OnServerCommunication; 
             OnSceneSync -= OnServerSceneSync;
         }
         private void OnServerCommunication()
         {
             Debug.Log("Communication was invoked", this);
         }
         private void OnServerSceneSync()
         {
             Debug.Log("Scene sync was invoked", this);
         }
    }
    
