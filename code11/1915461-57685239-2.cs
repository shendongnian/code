    public class MainThreadDispatcher : MonoBehaviour
    {
        private static MainThreadDispatcher _instance;
        public static MainThreadDispatcher Instance
        {
            get 
            {
                if(!_instance)
                {
                    _instance = new GameObject("MainThreadDispatcher").AddComponent<MainThreadDispatcher>();
                }
                return _instance;
            }
        }
        private ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();
        private void Update()
        {
            // work the queue in the main thread
            while(actions.TryDequeue(out var action))
            {
                action?.Invoke();
            }
        }
        public void Dispatch(Action action)
        {
            actions.Enqueue(action);
        }
    }
    
