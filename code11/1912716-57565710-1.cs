    interface ICommonDeviceInterface
    {
        int Id { get; set; }
    }
    class DeviceA : ICommonDeviceInterface
    {
        public int Id { get; set; }
        public string DevName { get; set; }
    }
    class DeviceB : ICommonDeviceInterface
    {
        public int Id { get; set; }
        public string DevName { get; set; }
    }
    class DeviceC : ICommonDeviceInterface
    {
        public int Id { get; set; }
    }
