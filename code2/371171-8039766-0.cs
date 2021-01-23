    private _data byte[];
    private bool _receiving = false;
    public void StartReceiving()
    {
        if (_receiving)
        {
            // ERROR: Already receiving
            throw new InvalidOperationException();
        }
        _receiving = true;
        Receive();
    }
    public void Receive()
    {
        if (_client.Connected)
        {
            _data = new byte[_client.ReceiveBufferSize];
            var ir _client.Client.BeginReceive(_data, 0, Convert.ToInt32(_client.ReceiveBufferSize), 0, ReceiveCallback, null);
    
            if (!_ir.WaitOne(20000)) 
            {
                //after 20 seconds of inactivity do some code to test if the connectio is alive                        
            }
        }
    }
    
    void ReceiveCallback(IAsyncResult ar)
    {
        Socket client = _cliente.Client;
        int bytesRead;
        try
        {
            bytesRead = client.EndReceive(ar);
            if (bytesRead > 0)
            {
                string response = Encoding.ASCII.GetString(_data, 0, bytesRead);
                doProcess(response);
                // Calling Receive here ensures that the timeout check happens
                // with every read.
                Receive();
            }
            else
            {
                _receiving = false;
            }
        }
        catch
        {
            // Catch SocketException and others here
        }
    }
