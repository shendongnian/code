    using Excel = Microsoft.Office.Interop.Excel;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {        
    class Program
    {
        [DllImport("Oleacc.dll")]
        public static extern int AccessibleObjectFromWindow(
              int hwnd, uint dwObjectID, byte[] riid,
              ref Microsoft.Office.Interop.Excel.Window ptr);
        public delegate bool EnumChildCallback(int hwnd, ref int lParam);
        [DllImport("User32.dll")]
        public static extern bool EnumChildWindows(
              int hWndParent, EnumChildCallback lpEnumFunc,
              ref int lParam);
        [DllImport("User32.dll")]
        public static extern int GetClassName(
              int hWnd, StringBuilder lpClassName, int nMaxCount);
        public static bool EnumChildProc(int hwndChild, ref int lParam)
        {
            StringBuilder buf = new StringBuilder(128);
            GetClassName(hwndChild, buf, 128);
            if (buf.ToString() == "EXCEL7")
            {
                lParam = hwndChild;
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Excel.Application app = new Excel.Application();
            EnumChildCallback cb;
            List<Process> procs = new List<Process>();
            procs.AddRange(Process.GetProcessesByName("excel"));
            foreach (Process p in procs)
            {
                if ((int)p.MainWindowHandle > 0)
                {
                    int childWindow = 0;
                    cb = new EnumChildCallback(EnumChildProc);
                    EnumChildWindows((int)p.MainWindowHandle, cb, ref childWindow);
                    if (childWindow > 0)
                    {
                        const uint OBJID_NATIVEOM = 0xFFFFFFF0;
                        Guid IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");
                        Excel.Window window = null;
                        int res = AccessibleObjectFromWindow(childWindow, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), ref window);
                        if (res >= 0)
                        {
                            app = window.Application;
                            Console.WriteLine(app.Name);
                        }
                    }
                }
            }
        }
    }
