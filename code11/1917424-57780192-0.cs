    public async Task<List<BlueToothDeviceInfo>> GetPairedDevices()
    {
        try
        {
            List<BlueToothDeviceInfo> blueToothDevices = new List<BlueToothDeviceInfo>();
    
            var task = Task.Run(async () =>
            {
                var deviceInfos = new List<BlueToothDeviceInfo>();
    
                if (bluetoothBLE.State == BluetoothState.On)
                {
                    adapter.ScanTimeout = ConnectionTimeout;
                    adapter.ScanMode = ScanMode.Balanced;
                    adapter.DeviceDiscovered += (s, a) =>
                    {
                        blueToothDevices.Add(new BlueToothDeviceInfo() { Name = a.Device.Name, HWAddress = a.Device.Id.ToString(), deviceInfoIOS = a.Device });
                        //here list added randomly
                    };
                    //We have to test if the device is scanning 
                    if (!bluetoothBLE.Adapter.IsScanning)
                    {
                        await adapter.StartScanningForDevicesAsync();
                    }    
                }
            });
    
            task.Wait();
    
            return blueToothDevices;
        }
        catch (Exception ex)
        {
            HelpClass.LogMessage(0, "BlueToothManager", LogMessageType.ErrorType, ex.StackTrace, ex);
            return null;
        }
    }
