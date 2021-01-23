    internal class Program
    {
        private const int WM_QUIT = 0x0012;
        private const int WM_CLOSE = 0x0010;
        [DllImport("user32.dll")]
        private static extern bool PostMessage(int hhwnd, uint msg);
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
        private static void QuitApplication(Process p)
        {
            Console.WriteLine("Posting quit message...");
            PostMessage(p.MainWindowHandle.ToInt32(), WM_QUIT);
        }
        private static void CloseMainWindow(Process p)
        {
            Console.WriteLine("Posting close message...");
            PostMessage(p.MainWindowHandle.ToInt32(), WM_CLOSE);
        }
    } 
