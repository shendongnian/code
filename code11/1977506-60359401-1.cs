    public Example<TInput>() : ITargetBlock 
    {
        private TaskCompletionSource<Object>tcs = new TaskCompletionSource<Object>()
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
        public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<in TInput> source, bool consumeToAccept)
        {
            if (Completion.IsCompleted)
            {
                return DataflowMessageStatus.DecliningPermanently;
            }
            // ...
        }
    }
