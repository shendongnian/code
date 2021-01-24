     public static async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DeviceInformationCollection ConnectedBluetoothDevices =
                   await DeviceInformation.FindAllAsync(BluetoothLEDevice.GetDeviceSelectorFromConnectionStatus(BluetoothConnectionStatus.Connected));
            if(ConnectedBluetoothDevices.Count != 0)
            {
                Console.WriteLine("New Device Found.");
            } 
        }
