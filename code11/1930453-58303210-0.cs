        static void Main(string[] args)
        {
            var processes = Process.GetProcesses();
            var process = processes.FirstOrDefault(p => p.Id == 13004);//the pid
            if (process == null) return;
            SwitchToThisWindow(process.MainWindowHandle, true);
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool turnOn);
