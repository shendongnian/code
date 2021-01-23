    private static TcpClient _client = null;
    private static Stream _s = null;
    private static StreamReader _sr = null;
    private static StreamWriter _sw = null;
    private static string _ipAddress = "";
    private static int _port = 0;
    private static System.Object _threadLock = new System.Object();
    
    /// <summary>
    /// Main method.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args) {
        try {
            if (args.Length == 3) {
                _ipAddress = args[1];
                _port = Convert.ToInt32(args[2]);
    
                EstablishSocketClient();
            }
    
            // Do stuff here
    
            if (args.Length == 3) Cleanup();
        } catch (Exception exception) {
            // Handle stuff here
            if (args.Length == 3) Cleanup();
        }
    }
    
    /// <summary>
    /// Establishes the socket client.
    /// </summary>
    private static void EstablishSocketClient() {
        _client = new TcpClient(_ipAddress, _port);
    
        try {
            _s = _client.GetStream();
            _sr = new StreamReader(_s, Encoding.Unicode);
            _sw = new StreamWriter(_s, Encoding.Unicode);
            _sw.AutoFlush = true;
        } catch (Exception e) {
            Cleanup();
        }
    }
    
    /// <summary>
    /// Clean up this instance.
    /// </summary>
    private static void Cleanup() {
        _s.Close();
        _client.Close();
    
        _client = null;
        _s = null;
        _sr = null;
        _sw = null;
    }
    
    /// <summary>
    /// Logs a message for output.
    /// </summary>
    /// <param name="message"></param>
    private static void Log(string message) {
        if (_sw != null) {
            _sw.WriteLine(message);
        } else {
            Console.Out.WriteLine(message);
        }
    }
