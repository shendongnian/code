    private const int SW_MAXIMIZE = 3;
    private const int SW_MINIMIZE = 6;
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    static void Main(string[] args) {
        string ipAddress = "xxx.xxx.xxx.xxx";
        Process proc = new Process();
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.FileName = "mstsc.exe";
        proc.StartInfo.Arguments = "/v:" + ipAddress ;    
        proc.Start();
        // NOTE: add some kind of delay to wait for the new process to be created.
        Process process = Process.GetProcessesByName("mstsc").First();
            
        ShowWindow(process.MainWindowHandle, SW_MINIMIZE);
    }
