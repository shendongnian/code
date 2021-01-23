    interface IDevice
    {
        string Name { get; }
        string DeviceType { get; }
        string[] State { get; set; }
    }
    class DeviceTypeOne : IDevice
    {
        // constructor omitted
        public string Name { get; }
        public string DeviceType { get; }
        public string[] State { get; set; }
    }
    class DeviceTypeTwo : IDevice
    {
        // constructor omitted
        public string Name { get; }
        public string DeviceType { get; }
        public string[] State { get; set; }
    }
    List<IDevice> devices = new List<IDevice>();
    devices.Add( new DeviceTypeOne( "Device1", "SomeType" ) );
    devices.Add( new DeviceTypeTwo( "Device2", "SomeType" ) );
    
    foreach( IDevice d in devices )
    {
        // do stuff with d.Name, d.State, and d.DeviceType
        // you now just deal with each object through the IDevice interface
    }
