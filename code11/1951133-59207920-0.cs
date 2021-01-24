    public class MainThreadDispatcher : MonoBehaviour
    {
        private static readonly ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();
    
        // This may be called be threads
        public static void ExecuteInUpdate(Action action)
        {
            // Add the action as new entry at the end of the queue
            actions.Enqueue(action);
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
