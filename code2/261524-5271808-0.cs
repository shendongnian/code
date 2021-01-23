    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                FindAndKill("Welcome");
                Thread.Sleep(1000);
            }
        }
        private static void FindAndKill(string caption)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                IntPtr pFoundWindow = p.MainWindowHandle;           
                StringBuilder windowText = new StringBuilder(256);
                GetWindowText(pFoundWindow, windowText, windowText.Capacity);
                if (windowText.ToString() == caption)
                {
                    p.CloseMainWindow();
                    Console.WriteLine("Excellent kill !!!");
                }
            }
        }
        [DllImport("user32.dll", EntryPoint = "GetWindowText",ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd,StringBuilder lpWindowText, int nMaxCount);
    }
