    public interface IService {}
    public interface IOtherService {}
    // Standard implementation of IService
    public class StandardService : IService {}
    // Alternative implementaion of IService
    public class SpecialService : IService {}
    public class OtherService : IOtherService {}
    public class Consumer
    {
        public Consumer(IService service, IOtherService otherService)
        {}
    }
    private void Test()
    {
        IUnityContainer parent = new UnityContainer()
            .RegisterType<IService, StandardService>()
            .RegisterType<IOtherService, OtherService>();
        // Here standardWay is initialized with StandardService as IService and OtherService as IOtherService
        Consumer standardWay = parent.Resolve<Consumer>();
        // We construct child container and override IService registration
        IUnityContainer child = parent.CreateChildContainer()
            .RegisterType<IService, SpecialService>();
        // And here specialWay is initialized with SpecialService as IService and still OtherService as IOtherService
        Consumer specialWay = child.Resolve<Consumer>();
        // Profit!
    }
