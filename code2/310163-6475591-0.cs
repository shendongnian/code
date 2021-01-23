    /// <summary>
    /// Allows you to start a specified program, or if it is already running, bring it into focus
    /// </summary>
    static class SFProgram
    {
        static public void StartFocus(string FileName, string ProcessName)
        {
            if (!ProcessStarted(ProcessName))
                Process.Start(FileName);
            else
                SFProgram.BringWindowToTop("notepad");
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// Bring specified process to focus
        /// </summary>
        /// <param name="windowName">Process Name</param>
        /// <returns>If it was successful</returns>
        private static bool BringWindowToTop(string windowName)
        {
            Process[] processes = Process.GetProcessesByName(windowName);
            foreach (Process p in processes)
            {
                int hWnd = (int)p.MainWindowHandle;
                if (hWnd != 0)
                {
                    return SetForegroundWindow((IntPtr)hWnd);
                }
                //p.CloseMainWindow();
            }
            return false;
        }
        private static bool ProcessStarted(string ProcessName)
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            return (processes.Length > 0);
        }
    }
