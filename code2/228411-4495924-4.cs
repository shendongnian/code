    internal class Program
    {
        private const int WM_QUIT = 0x0012;
        private const int WM_CLOSE = 0x0010;
        [DllImport("user32.dll")]
        private static extern bool PostMessage(int hhwnd, uint msg, IntPtr wParam, IntPtr lParam);
        private static void Main()
        {
            Process p = GetProcess("Your process name - no '.exe' required");
            CloseMainWindow(p);
        }
        private static Process GetProcess(string name)
        {
            List<Process> processes = Process.GetProcessesByName(name).ToList();
            if (processes.Count != 1)
            {
                throw new Exception(
                  "Expected 1 process with name '" + name +
                  "' but found " + processes.Count + ".");
            }
            return processes[0];
        }
        private static void CloseMainWindow(Process p)
        {
            PostMessage(p, WM_CLOSE, "close");
        }
        private static void QuitApplication(Process p)
        {
            PostMessage(p, WM_QUIT, "quit");
        }
        private static void PostMessage(Process p, uint message, string name)
        {
            Console.WriteLine("Posting {0} message to '{1}'...", name, p.ProcessName);
            bool succeeded = PostMessage(p.MainWindowHandle.ToInt32(), message, IntPtr.Zero, IntPtr.Zero);
            Console.WriteLine("Posted {0} message to '{1}' (succeeded:{2}).", name, p.ProcessName, succeeded);
        }
    } 
