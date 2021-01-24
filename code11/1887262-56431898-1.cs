    class CallTaskFactory : ICallTaskFactory
    {
        private Container container;
        
        public CallTaskFactory(Container container)
        {
            this.container = container;
        }
        public async Task CreateCallTask()
        {
            using (AsyncScopedLifestyle.BeginScope(this.container))
            {
                await this.container.GetInstance<CallExecutor>().Call();
            }
        }
    }
