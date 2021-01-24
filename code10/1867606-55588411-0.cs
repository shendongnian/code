    var client = new BluetoothClient();
    // Select the bluetooth device
    var dlg = new SelectBluetoothDeviceDialog();
    DialogResult result = dlg.ShowDialog(this);
    if (result != DialogResult.OK)
    {
        return;
    }
    BluetoothDeviceInfo device = dlg.SelectedDevice;
    BluetoothAddress addr = device.DeviceAddress;
    Console.WriteLine(device.DeviceName);
    BluetoothSecurity.PairRequest(addr, "PIN"); // set the pin here or take user input
    device.SetServiceState(BluetoothService.HumanInterfaceDevice, true);
    Thread.Sleep(100); // Precautionary
    if (device.InstalledServices.Length == 0)
    {
        // handle appropriately
    }
    client.Connect(addr, BluetoothService.HumanInterfaceDevice);
