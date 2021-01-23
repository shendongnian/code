        public static bool Report(IntPtr hWnd, IntPtr lParam)
        {
            if (getWindowClassName(hWnd).Contains("tool"))
            {
                AutomationElement element = AutomationElement.FromHandle(hWnd);
                string value = element.Current.Name;
                if (value.Length > 0)
                {
                    uint currentWindowProcessId = 0;
                    GetWindowThreadProcessId(currentWindowHWnd, out currentWindowProcessId);
                    if (element.Current.ProcessId == currentWindowProcessId)
                        Console.WriteLine(value);
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            callBackPtr = new CallBackPtr(Report);
            do
            {
                System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position; // use Windows forms mouse code instead of WPF
                currentWindowHWnd = WindowFromPoint(mouse);
                if (currentWindowHWnd != IntPtr.Zero)
                    EnumChildWindows((IntPtr)0, callBackPtr, (IntPtr)0);
                Thread.Sleep(1000);
            }
            while (true);
        }
