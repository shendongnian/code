    public class TransientDependencyProxy<T> : ITransientDependency
        where T : ITransientDependency
    {
        private readonly UnityContainer container;
        public TransientDependencyProxy(UnityContainer container)
        {
            this.container = container;
        }
        public SomeAction()
        {
            this.container.Resolve<T>().SomeAction();
        }
    }
