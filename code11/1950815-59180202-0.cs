csharp
public interface IDevice
{
    event DeviceVarChange<IVar> VarChange;
}
public interface IVar
{
    // ...
}
public delegate void DeviceVarChange<TVar>(TVar theVar) where TVar : IVar;
public interface ISpecificDevice : IDevice
{
    // Overload the event inside the interface with the specific class
    new event DeviceVarChange<ISpecificVar> VarChange;
}
public interface ISpecificVar : IVar
{
    // ...
}
public class SpecificDevice : ISpecificDevice
{
    // Dear maintainer,
    // Forgive me.
    // Regards
    private void FireVarChange(ISpecificVar theVar)
    {
        lock (delegatesForVarChange)
        {
            foreach (var theDelegate in delegatesForVarChange)
            {
                theDelegate.Invoke(theVar);
            }
        }
    }
    private List<dynamic> delegatesForVarChange = new List<dynamic>();
    event DeviceVarChange<IVar> IDevice.VarChange
    {
        add
        {
            lock (delegatesForVarChange)
            {
                delegatesForVarChange.Add(value);
            }
        }
        remove
        {
            lock (delegatesForVarChange)
            {
                delegatesForVarChange.Remove(value);
            }
        }
    }
    public event DeviceVarChange<ISpecificVar> VarChange
    {
        add
        {
            lock (delegatesForVarChange)
            {
                delegatesForVarChange.Add(value);
            }
        }
        remove
        {
            lock (delegatesForVarChange)
            {
                delegatesForVarChange.Remove(value);
            }
        }
    }
}
// Try to use a specific instance as a base one
public class Test
{
    public void DoTest()
    {
        var genericDevice = GetSpecificDeviceAsBase();
        // Success
        genericDevice.VarChange += OnVarChange;
    }
    public IDevice GetSpecificDeviceAsBase()
    {
        return new SpecificDevice();
    }
    public void OnVarChange(IVar theVar)
    {
        // ...
    }
}
