    void ScanForBluetoothClients()
    {
        var client = new BluetoothClient();
        BluetoothDeviceInfo[] availableDevices = client.DiscoverDevices(); // I've found this to be SLOW!
        foreach (BluetoothDeviceInfo device in availableDevices)
        {
            if (!device.Authenticated)
            {
                continue;
            }
            var peerClient = new BluetoothClient();
            peerClient.BeginConnect(deviceInfo.DeviceAddress, BluetoothService.SerialPort, this.BluetoothClientConnectCallback, peerClient);
        }
    }
