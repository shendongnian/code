    public interface IRepository { }
    public class Repository : IRepository { }
    
    public class Service
    {
        //[InjectionConstructor]
        public Service()
        {
            Console.WriteLine("Parameterless constructor called");
        }
    
        public Service(IRepository repository)
        {
            Console.WriteLine("Contructor with IRepository called");
        }
    }
    private static void Main()
    {
        var container = new UnityContainer();
        container.RegisterType<IRepository, Repository>();
        var service = container.Resolve<Service>();
        container.RegisterType<Service>(new InjectionConstructor());
        var service2 = container.Resolve<Service>();
    }
