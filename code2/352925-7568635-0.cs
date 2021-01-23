    public struct TaskAwaiter 
    { 
        public bool IsCompleted { get; }
        public void OnCompleted(Action continuation); 
        public void GetResult(); 
    }
