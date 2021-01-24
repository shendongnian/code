    interface IAbstractWorker
    {
        Task ExecuteAsync();
    }
    abstract class AbstractSepcializedWorker : IAbstractWorker
    {
        public async Task ExecuteAsync()
        {
            OutputModel output = await PerformActions();
            await HandleOutput(output);
        }        
        protected abstract Task<OutputModel> PerformActionsAsync();
        protected abstract Task HandleOutputAsync(OutputModel);
    }
    
    
    class Worker : IAbstractWorker
    {
        public async Task ExecuteAsync()
        {
            // implementation
        }
    }
    
    class SepcializedWorker : AbstractSepcializedWorker
    {
    
        protected override Task<OutputModel> PerformActionsAsync()
        {
            // implementation
        }
        protected override Task HandleOutputAsync(OutputModel)
        {
            // implementation
        }
    }
