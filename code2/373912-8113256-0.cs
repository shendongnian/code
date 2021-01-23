    public class SessionFactory : ISessionFactory
    {
        private IKernel kernel;
        public SessionFactory(IKernel kerenl)
        {
            this.kernel = kernel;
        }
        public ISession CreateSession(string name)
        {
            this.kernel.Get<ISession>(new ConstructorArgument("name", name));
        }
    }
