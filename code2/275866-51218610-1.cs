    private static bool _continue;
    private static SerialPort _serialPort;
    
    public static void Main()
    {
        var stringComparer = StringComparer.OrdinalIgnoreCase;
        var readThread = new Thread(Read);
    
        _serialPort = new SerialPort
        {
            PortName = "COM2",
            ReadTimeout = 500,
            WriteTimeout = 500
        };
    
        _serialPort.Open();
        _continue = true;
        readThread.Start();
    
        while (_continue)
        {
            var message = Console.ReadLine();
    
            if (stringComparer.Equals("quit", message))
            {
                _continue = false;
            }
            else
            {
                _serialPort.WriteLine(message);
            }
        }
    
        readThread.Join();
        _serialPort.Close();
    }
    
    public static void Read()
    {
        while (_continue)
        {
            try
            {
                var message = _serialPort.ReadLine();
                Console.WriteLine(message);
            }
            catch (TimeoutException) { }
        }
    }
