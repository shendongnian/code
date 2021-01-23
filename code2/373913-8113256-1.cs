    public class SessionFactory : ISessionFactory
    {
        private IKernel kernel;
        public SessionFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public ISession CreateSession(string name)
        {
            return this.kernel.Get<ISession>(new ConstructorArgument("name", name));
        }
    }
