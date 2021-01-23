    using System;
    namespace TestDrive
    {
        class Program
        {
            static void Main( string[] args )
            {
                ServiceConsumer x = new ServiceConsumer( new ConcreteService2() ) ;
                x.FunnyMethod() ;
                return ;
            }
        }
        abstract class AbstractService
        {
            public abstract void DoSomethingInteresting() ;
        }
        class ConcreteService1 : AbstractService
        {
            public override void DoSomethingInteresting()
            {
                Console.WriteLine("I did something interesting!");
                return ;
            }
        }
        class ConcreteService2 : ConcreteService1
        {
            public override void DoSomethingInteresting()
            {
                base.DoSomethingInteresting() ;
                Console.WriteLine("So Did I!");
                return ;
            }
        }
        class ConcreteService : AbstractService
        {
            public override void DoSomethingInteresting()
            {
                Console.WriteLine("Not It's my turn to do something interesting!") ;
                return ;
            }
        }
        class ServiceConsumer
        {
            private AbstractService Service ;
            public ServiceConsumer( AbstractService serviceInstance )
            {
                this.Service = serviceInstance ;
                return ;
            }
            public void FunnyMethod()
            {
                Service.DoSomethingInteresting() ;
                return ;
            }
        }
    }
