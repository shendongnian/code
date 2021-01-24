 c#
public class DeviceAccess
{
    private Container _container;
    public DeviceAccess() {}
    public async ValueTask OpenAsync(Database database) {
        if (_container == null)
            _container = await GetContainerAsync(database);
    }
    public async Task<Device> GetDeviceAsync(string deviceId)
    {
        var container = _container ?? throw new InvalidOperationException("not open");
        return await doSomething(container); // might be able to inline the "await" here
    }
}
