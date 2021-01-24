    public class MainThreadWorker : MonoBehaviour
    {
        // singleton pattern
        public static MainThreadWorker Instance;
    
        // added actions will be executed in the main thread
        ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();
    
        private void Awake()
        {
            if (Instance)
            {
                this.enabled = false;
                return;
            }
            Instance = this;
        }
    
        private void Update()
        {
            // execute all actions added since the last frame
            while (actions.TryDequeue(out var action))
            {
                action?.Invoke();
            }
        }
    
        public void AddAction(Action action)
        {
            if(action != null) actions.Enqueue(action);
        }
    }
    
