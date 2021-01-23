    class Device
    {
        public Device( string name, string type, string[] state = null )
        {
            Name = name;
            DeviceType = type;
            State = state;
        }
        string DeviceType { get; }
        string Name { get; }
        string[] State { get; set; }
    }
