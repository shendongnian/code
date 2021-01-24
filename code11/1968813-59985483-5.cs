cs
public interface IThirdPartySystem
{
    void Method1();
    void Method2();
}
public class ThirdPartySystem1 : IThirdPartySystem
{
    //implementation
}
public class ThirdPartySystem2 : IThirdPartySystem
{
    //implementation
}
public class AACSCaller 
{
    IList<IThirdPartySystem> _systems = new List<IThirdPartySystem>();
    public AACSCaller(Settings appSettings)
    {
        _appSettings = appSettings;
        if (appSettings.system1Enabled)
        {
            _systems.Add(new ThirdPartySystem1());
        }
        if (appSettings.system2Enabled)
        {
            _systems.Add(new ThirdPartySystem2());
        }
    }
    public void Method1()
    {
        foreach (var system in _systems)
            system.Method1();           
    }
    public void Method2()
    {
         foreach (var system in _systems)
            system.Method2();            
    }
}
