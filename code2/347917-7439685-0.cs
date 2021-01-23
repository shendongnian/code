    void Main()
    {
        IUnityContainer container = new UnityContainer();
        
        container.RegisterType<IScheduler, DailyScheduler>("Daily");
        
        var schedulerMock = new Mock<IScheduler>();
        schedulerMock.Setup(x => x.Name).Returns("Mock!");
        container.RegisterInstance("Daily", schedulerMock.Object);
        
        IScheduler s = container.Resolve<IScheduler>("Daily");
        
        Console.WriteLine(s.Name);  // Prints "Mock!"
    }
    
    public interface IScheduler
    {
        string Name { get; }
    }
    
    public class DailyScheduler: IScheduler
    {
        public string Name { get { return "Daily!"; } }
    }
