     BluetoothAdapter bluetoothAdapter;
        IEnumerable<BluetoothDevice> bondeddevices;
        
        private void  removepairdevice()
        {
            bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
             bondeddevices = bluetoothAdapter.BondedDevices;
            foreach(BluetoothDevice device in bondeddevices)
            {
                unpairdevice(device);
            }
        }
        private void unpairdevice(BluetoothDevice device)
        {
            try
            {
                Method m = device.Class.GetMethod("removeBond",null);
                m.Invoke(device,null);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
