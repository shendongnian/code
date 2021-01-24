    public Example() : ITargetBlock 
    {
        var tcs = new TaskCompletionSource<Object>()
        public Task Completion { get; }
        public Example()
        {
            Completion = tcs.Task;
        }
        public void Complete()
        {
            // Wait here for any currently executing async work your dataflow block does to finish.
            // ...
            
            tcs.TrySetResult(null);
        }
        public void Fault (Exception exception)
        {
            // Cancel here any running work.
            // ...
            tcs.TrySetException(exception);
        }
        //...
    }
