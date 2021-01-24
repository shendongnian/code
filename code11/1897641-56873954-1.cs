c#
public class MainClass
{
    private readonly IUtilityRepository _utilityRepo = null;
    public MainClass()
    {
    }
    public MainClass(IKernel kernel)
    {
        var userId = new Ninject.Parameters.ConstructorArgument("userId", 123);
        var sessionId = new Ninject.Parameters.ConstructorArgument("sessionId", 456);
        _utilityRepo = kernel.Get<IUtilityRepository>(userId, sessionId);
    }
}
In this way `UtilityRepository` will be able to receive the two parameters in the constructor:
c#
public class UtilityRepository : IUtilityRepository
{
    private readonly int _userId;
    private readonly int _sessionId;
    // maybe have here some constructor where i can get some values from MainClass
    public  UtilityRepository (int userId, int sessionId)
    {
        _userId = userId;
        _sessionId = sessionId;
    }
    public List<string> MethodTestOne(string tempFolder)
    {
        // do something...
    }
    public List<string> MethodTestTwo(string tempFolder)
    {
        // do something...
    }
}
Note that in such a case, the registration of `UtilityRepository` must be transient, so that a new instance is created every time it's requested with the specific parameter values:
c#
kernel.Bind<IUtilityRepository>().To<UtilityRepository>().InTransientScope();
One downside of this solution is that `MainClass` doesn't use constructor parameters any longer in order to explicitly declare its dependencies. The code is now less self-documenting.
