    List<Device> devices = new List<Device>();
    devices.Add( new Device( "Device1", "SomeType" ) );
    devices.Add( new Device( "Device2", "SomeType" ) );
    devices.Add( new Device( "Device3", "SomeType" ) );
    
    foreach( Device d in devices )
    {
        // do stuff with d.Name, d.State, and d.DeviceType
    }
