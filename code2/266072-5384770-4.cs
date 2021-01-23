    class Device
    {
        public Device( string name, string type, string[] state = null )
        {
            Name = name;
            DeviceType = type;
            State = state;
        }
        public string Name { get; }
        public string DeviceType { get; }
        public string[] State { get; set; }
    }
