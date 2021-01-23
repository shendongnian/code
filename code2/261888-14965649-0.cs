    static class Program
    {
        [DllImport("User32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
    
    
    
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            int iP;
            Process currentProcess = Process.GetCurrentProcess();
            Mutex m = new Mutex(true, "XYZ", out createdNew);
            if (!createdNew)
            {
                // app is already running...
                Process[] proc = Process.GetProcessesByName("XYZ");
                
                // switch to other process
                for (iP = 0; iP < proc.Length; iP++)
                {
                    if (proc[iP].Id != currentProcess.Id)
                        SwitchToThisWindow(proc[0].MainWindowHandle, true);
                }
    
                return;
            }
    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new form());
            GC.KeepAlive(m);
    
        }
