        static Process myProcess;
        [STAThread]
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                //count how many procesess with this name are active if more than zero its still alive
                Process[] proc = Process.GetProcessesByName("myprog");
                if (proc.Length > 0)
                {
                    //its alive check if it has focus
                    if (proc[0].MainWindowHandle != GetForegroundWindow())
                    {
                        SetFocus(proc[0].MainWindowHandle);
                    }
                }
                //no process start new one and focus on it
                else
                {
                    myProcess = new Process();
                    myProcess.StartInfo.FileName = "C:\\aa\\myprog.exe";
                    myProcess.Start();
 
                    SetFocus(myProcess.Handle);
                }
                Thread.Sleep(1000);
            }
        }
        private static void SetFocus(IntPtr handle)
        {
            SwitchToThisWindow(handle, true);
        }
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
