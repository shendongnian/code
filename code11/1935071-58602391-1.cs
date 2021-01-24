    private static void QueryDisplayDevices()
    {
        DISPLAY_DEVICE device = new DISPLAY_DEVICE();
        device.Initialize();
        uint DispNum = 0;
        while (EnumDisplayDevices(null, DispNum, ref device, 0))
        {
            DISPLAY_DEVICE dev = new DISPLAY_DEVICE();
            dev.Initialize();
            if (EnumDisplayDevices(device.DeviceName, 0, ref dev, 0))
           {
                Console.WriteLine("Device Name:" + dev.DeviceName);
                Console.WriteLine("Monitor name:" + dev.DeviceString);
           }
           DispNum++;
           device.Initialize();
        }
    }
