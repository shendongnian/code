    private static void Main()
    {
        // Add three different types, which all implement the same interface, to our list
        var devices = new List<ICommonDeviceInterface>
        {
            new DeviceA {DevName = "CompanyA", Id = 1},
            new DeviceB {DevName = "CompanyB", Id = 2},
            new DeviceC {Id = 3},
        };
        var partnerName = "CompanyB";
        foreach (var device in devices)
        {
            // Try to get the "DevName" property for this object
            var devName = GetPropValue(device, "DevName");
            // See if the devName matches the partner name
            if (partnerName.Equals(devName))
            {
                Console.WriteLine($"Found a match with Id: {device.Id}");
            }
        }
    }
