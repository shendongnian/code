    bool PairDevice()
    {
        using (var discoverForm = new SelectBluetoothDeviceDialog())
        {
            if (discoverForm.ShowDialog(this) != DialogResult.OK)
            {
                // no device selected
                return false;
            }
            BluetoothDeviceInfo deviceInfo = discoverForm.SelectedDevice;
            if (!deviceInfo.Authenticated) // previously paired?
            {
                // TODO: show a dialog with a PIN/discover the device PIN
                if (!BluetoothSecurity.PairDevice(deviceInfo.DeviceAddress, myPin)) 
                {
                    // not previously paired and attempt to pair failed
                    return false;
                }
            }
            // device should now be paired with the OS so make a connection to it asynchronously
            var client = new BluetoothClient();
            client.BeginConnect(deviceInfo.DeviceAddress, BluetoothService.SerialPort, this.BluetoothClientConnectCallback, client);
            return true;
        }
    }
    void BluetoothClientConnectCallback(IAsyncResult result)
    {
        var client = (BluetoothClient)result.State;
        client.EndConnect();
        // get the client's stream and do whatever reading/writing you want to do.
        // if you want to maintain the connection then calls to Read() on the client's stream should block when awaiting data from the device
        // when you're done reading/writing and want to close the connection or the device servers the connection control flow will resume here and you need to tidy up
        client.Close();
    }
