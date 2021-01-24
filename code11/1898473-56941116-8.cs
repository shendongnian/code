    public interface IServiceA
    {
        ISharedService SharedService { get; }
    }
    public interface IServiceB
    {
        ISharedService SharedService { get; }
    }
    public class ServiceA : IServiceA
    {
        public ServiceA(ISharedService sharedService)
        {
            SharedService = sharedService;
        }
        public ISharedService SharedService { get; }
    }
    public class ServiceB : IServiceB
    {
        public ServiceB(ISharedService sharedService)
        {
            SharedService = sharedService;
        }
        public ISharedService SharedService { get; }
    }
    public interface ISharedService { }
    public class SharedService : ISharedService { }
