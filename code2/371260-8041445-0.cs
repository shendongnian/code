    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IMyServiceContract
    {
       ...
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MyServiceImplementation: IMyServiceContract
    {
       ...
    }
