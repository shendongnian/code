    public class MainThreadDispatcher : MonoBehaviour
    {
        // Singleton pattern
        private static MainThreadDispatcher _instance;
        private readonly ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();
    
        // This may be called by threads
        public static void ExecuteInUpdate(Action action)
        {
            if(!_instance)
            {
                Debug.LogError("You can talk but nobody is listening../nNo MainThreadDispatcher in scene!");
                return;
            }
            // Add the action as new entry at the end of the queue
            _instance.actions.Enqueue(action);
        }
        // This will be executed when the game is started!
        // See https://docs.unity3d.com/ScriptReference/RuntimeInitializeOnLoadMethodAttribute.html
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            // Initialize the Singleton and make sure an instance exists
            if(_instance) Destroy(_instance.gameObject);
            _instance = new GameObject("MainThreadDispatcher"). AddComponent<MainThreadDispatcher>();
            DontDestroyOnLoad(_instance);
        }
    
        // Executed in the Unity main thread
        private void Update()
        {
            // Every frame check if any actions are enqueued to be executed
            while(actions.TryDequeue(out car action)
            {
                action?.Invoke();
            }
        }
    }
