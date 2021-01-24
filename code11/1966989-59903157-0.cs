public class BrainboxController : IDisposable
{
    private readonly HashSet<string> _deviceIps; // potentially you can get away without having this if you call InitialiseDevices() in the constructor
    private Dictionary<string, EDDevice> _devices = new Dictionary<string, EDDevice>(); // possibly use IDevice<C, P> instead of EDDevice
    public BrainboxController(IEnumerable<string> devices)
    {
        _deviceIps = new HashSet<string>(devices);
    }
    public void InitialiseDevices()
    {
        foreach (string ip in _deviceIps)
            _devices.Add(ip, EDDevice.Create(ip));
    }
    public void AddDevice(string ip)
    {
        if (_deviceIps.Add(ip))
            _devices.Add(ip, EDDevice.Create(ip));
    }
    public void RemoveDevice(string ip)
    {
        if(_devices.ContainsKey(ip))
        {
            var device = _devices[ip];
            device.Disconnect();
            device.Dispose();
            _devices.Remove(ip);
            _deviceIps.Remove(ip);
        }
    }
    public EDDevice GetDevice(string deviceIp)
    {
        if (_devices.ContainsKey(deviceIp))
            return _devices[deviceIp];
        return null;
    }
    public string GetConfiguration(string deviceIp)
    {
        if (_devices.ContainsKey(deviceIp))
            return _devices[deviceIp].Describe(); // I'm assuming that this gets the config data
        return "Device not found";
    }
    public bool SetConfiguration(string deviceIp, string xml)
    {
        if (_devices.ContainsKey(deviceIp))
        {
            _devices[deviceIp].SendCommand(xml); // I'm assuming this is how the config data is set
            return true;
        }
                
        // log device not found
        return false;
    }
    public IOList<IOLine> GetOutputs(string deviceIp, int relay)
    {
        if (_devices.ContainsKey(deviceIp))
            return _devices[deviceIp].Outputs[relay];
        // log device not found
        return new IOList<IOLine>();
    }
    public void Dispose()
    {
        foreach(var device in _devices.Values)
        {
            device.Disconnect();
            device.Dispose();
        }
    }
}
Strictly speaking, if you follow the single responsibility principle, this class should just be managing your devices and their connections. The methods `GetConfiguration()`, `SetConfiguration()` and `GetOutputs()` are shown as examples and really should live somewhere else.
Your calling code could be look like this (without dependency injection):
var deviceAddresses = new[] { "192.168.16.147", "192.168.16.148", "192.168.16.149", "192.168.16.150" };
var controller = new BrainboxController(deviceAddresses);
controller.InitialiseDevices();
var currentDevice = controller.GetDevice("192.168.16.147");
// do something with currentDevice
Finally, whatever it is you're trying to do with your `Outputs` method, that looks like business logic and this also should live somewhere else.
  [1]: http://www.brainboxes.com/files/pages/support/faqs/sample_code/Brainboxes.IO.Documentation/html/N_Brainboxes_IO.htm
