    public class DeviceTotalView : IDeviceView
    {
    	public Guid DeviceId { get; set; }
    	public int Voltage { get; set; }
    	public int Currents { get; set; }
    	public object Clone() => this.MemberwiseClone();
    	public static DeviceTotalView GetInitialView(Guid deviceId)
    	{
    		return new DeviceTotalView
    		{
    			DeviceId = deviceId,
    			Voltage = 0,
    			Currents = 0
    		};
    	}
    }
