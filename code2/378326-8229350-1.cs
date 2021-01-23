    public class ClientFactory: IClientFactory
    {
        private IKernel kernel;
        public ClientFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }
    
        public IClient CreateClient()
        {
            return this.kernel.Get<IClient>();
        }
    }
