    public class ComposedServices : IServiceA, IServiceB
    {
        private IServiceA serviceA;
        private IServiceB serviceB;
        public ComposedServices(IServiceA serviceA, IServiceB serviceB)
        {
            this.serviceA = serviceA; 
            this.serviceB = serviceB;
        }
        
        public void SomeMetodFromA()
        {
            this.serviceA.SomeMethodFromA();
        }
    }
