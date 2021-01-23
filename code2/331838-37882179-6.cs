    public class StrategyResolver : IStrategyResolver
    {
        private IUnityContainer container;
    
        public StrategyResolver(IUnityContainer unityContainer)
        {
            this.container = unityContainer;
        }
    
        public T Resolve<T>(string namedStrategy)
        {
            return this.container.Resolve<T>(namedStrategy);
        }
    }
