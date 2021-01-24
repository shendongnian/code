        private readonly SerialPort _port = null;
        public MySerialPort(string comPortName)
        {
            ComPortName = comPortName;
            _port = new SerialPort(ComPortName,
                9600, Parity.None, 8, StopBits.One);
             _port.Open();
             var rxData = Task.Run(async () => await ReceiveData());
            // ...
        }
    public async Task<Stream> ReceiveData()
    {
        var buffer = new byte[4096];
        int readBytes = 0;
        using (MemoryStream memoryStream = new MemoryStream())
        {
            while ((readBytes = await _port.BaseStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, readBytes);
            }
    
            return memoryStream;
        }
    }
