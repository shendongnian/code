    public class ExampleTaskTracker
    {
        // the task we're awaiting if there one
        Task<object> task;
        // initiates the process
        public void Start()
        {
            if (task == null || task.IsCompleted)
                task = Task.Delay(5000).ContinueWith((o) => new object());
        }
       
        // waits the process to finish if there's one
        public async Task<object> End()
        {
            if (task == null)
                return null;
            return await task;
        }
    }
