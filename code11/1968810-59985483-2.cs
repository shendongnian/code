cs
public interface I3rdPartySystem
{
    void Method1();
    void Method2();
}
public class 3rdPartySystem1 : I3rdPartySystem
{
    //implementation
}
public class 3rdPartySystem2 : I3rdPartySystem
{
    //implementation
}
public class AACSCaller 
{
    IList<I3rdPartySystem> _systems = new List<I3rdPartySystem>();
    public AACSCaller(Settings appSettings)
    {
        _appSettings = appSettings;
        if (appSettings.system1Enabled)
        {
            _systems.Add(new 3rdPartySystem1());
        }
        if (appSettings.system2Enabled)
        {
            _systems.Add(new 3rdPartySystem2());
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
