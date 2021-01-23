    public class MyController
    {
        private ServiceA serviceA;
        private ServiceB serviceB;
         
        public MyController(ServiceA serviceA, ServiceB serviceB)
        {
            this.serviceA = serviceA;
            this.serviceB = serviceB;
        }
        public void MyMethod()
        {
            // We don't need to check null because the dependency injection container 
            // injects it, provided you took care of bootstrapping it.
            var someObject = serviceA.DoThis();
        }
    }
