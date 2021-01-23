    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
    [DllImport("kernel32.dll",
        EntryPoint = "GetStdHandle",
        SetLastError = true,
        CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr GetStdHandle(int nStdHandle);
    [DllImport("kernel32", SetLastError = true)]
    static extern bool AttachConsole(uint dwProcessId);
    [DllImport("kernel32.dll",
        EntryPoint = "AllocConsole",
        SetLastError = true,
        CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
    private static extern int AllocConsole();
    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern bool FreeConsole();
    private const int STD_OUTPUT_HANDLE = -11;
    private const int STD_ERROR_HANDLE = -12;
    private static bool _consoleAttached = false;
    [STAThread]
    static void Main()
    {
        args = new List<string>(Environment.GetCommandLineArgs());
        int prId;
        IntPtr ptr = GetForegroundWindow();            
        GetWindowThreadProcessId(ptr, out prId);
        Process process = Process.GetProcessById(prId);
        if (args.Count > 1 && process.ProcessName == "cmd")
        {
            if (AttachConsole((uint)prId)) { //AllocConsole() != 0) {
                _consoleAttached = true;
                IntPtr stdHandle = GetStdHandle(STD_ERROR_HANDLE); // must be error dunno why
                SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
                FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
                Encoding encoding = Encoding.ASCII;
                StreamWriter standardOutput = new StreamWriter(fileStream, encoding);
                standardOutput.AutoFlush = true;
                Console.SetOut(standardOutput);
                if (args.Contains("/debug")) Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Console.WriteLine(Application.ProductName + " was launched from a console window and will redirect output to it.");
            }
        }
        // ... do whatever, use console.writeline or debug.writeline
        // if you started the app with /debug from a console
        Cleanup();
    }
    private static void Cleanup() {
        try
        {
            if (_consoleAttached)
            {
                SetForegroundWindow(consoleWindow);
                SendKeys.SendWait("{ENTER}");
                FreeConsole();
            }    
        }        
    }
