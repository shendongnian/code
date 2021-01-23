    public class Service
    {
        public virtual void DoSomething()
        {
            
        }
    }
    public class ServiceA : Service
    {
        public override void DoSomething()
        {
        }
    }
    public class ServiceB : Service
    {
        public override void DoSomething()
        {
        }
    }
    public class ServiceA_B : Service
    {
        ServiceA serviceA = new ServiceA();
        ServiceB serviceB = new ServiceB();
        public override void DoSomething()
        {
            serviceA.DoSomething();
            serviceB.DoSomething();   
        }
    }
