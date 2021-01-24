    interface IAbstractWorker
    {
        void Execute();
    }
    abstract class AbstractSepcializedWorker : IAbstractWorker
    {
        public void Execute()
        {
            OutputModel output = await PerformActions();
            await HandleOutput(output);
        }        
        protected abstract Task<OutputModel> PerformActions();
        protected abstract Task HandleOutput(OutputModel);
    }
    
    
    class Worker : IAbstractWorker
    {
        public void Execute()
        {
            // implementation
        }
    }
    
    class SepcializedWorker : AbstractSepcializedWorker
    {
    
        protected override Task<OutputModel> PerformActions()
        {
            // implementation
        }
        protected override Task HandleOutput(OutputModel)
        {
            // implementation
        }
    }
