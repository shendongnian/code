    void SetupListener()
    {
        var listener = new BluetoothListener(BluetoothService.SerialPort);
        listener.Start();
        listener.BeginAcceptBluetoothClient(this.BluetoothListenerAcceptClientCallback, listener);
    }
    
    
    void BluetoothListenerAcceptClientCallback(IAsyncResult result)
    {
        var listener = (BluetoothListener)result.State;
    
        // continue listening for other broadcasting devices
        listener.BeginAcceptBluetoothClient(this.BluetoothListenerAcceptClientCallback, listener);
    
        // create a connection to the device that's just been found
        BluetoothClient client = listener.EndAcceptBluetoothClient();
    
        // the method we're in is already asynchronous and it's already connected to the client (via EndAcceptBluetoothClient) so there's no need to call BeginConnect
        // TODO: perform your reading/writing as you did in the first code sample
    
        client.Close();
    }
