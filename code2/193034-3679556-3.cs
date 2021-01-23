    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using Word = Microsoft.Office.Interop.Word;
    
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00020400-0000-0000-C000-000000000046")]
    public interface IDispatch
    {
    }
    
    class StartupWatch
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
        [DllImport("Oleacc.dll")]
        static extern int AccessibleObjectFromWindow(IntPtr hwnd, uint dwObjectID, byte[] riid, out IDispatch ptr);
    
        public delegate bool EnumChildCallback(IntPtr hwnd, ref IntPtr lParam);
    
        [DllImport("User32.dll")]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildCallback lpEnumFunc, ref IntPtr lParam);
    
        [DllImport("User32.dll")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    
        public static bool EnumChildProc(IntPtr hwndChild, ref IntPtr lParam)
        {
            StringBuilder buf = new StringBuilder(128);
            GetClassName(hwndChild, buf, 128);
            if (buf.ToString() == "_WwG")
            {
                lParam = hwndChild;
                return false;
            }
            return true;
        }
    
        static Word.Application GetWordApplicationObject(Process process)
        {
            Word.Application wordApp = null;
            if (process.MainWindowHandle != IntPtr.Zero)
            {
                IntPtr hwndChild = IntPtr.Zero;
    
                // Search the accessible child window (it has class name "_WwG") 
                // as described in http://msdn.microsoft.com/en-us/library/dd317978%28VS.85%29.aspx
                //
                // adjust this class name inside EnumChildProc accordingly if you are 
                // creating another COM server than Word
                //
                EnumChildCallback cb = new EnumChildCallback(EnumChildProc);
                EnumChildWindows(process.MainWindowHandle, cb, ref hwndChild);
    
                if (hwndChild != IntPtr.Zero)
                {
                    // We call AccessibleObjectFromWindow, passing the constant OBJID_NATIVEOM (defined in winuser.h) 
                    // and IID_IDispatch - we want an IDispatch pointer into the native object model.
                    //
                    const uint OBJID_NATIVEOM = 0xFFFFFFF0;
                    Guid IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");
                    IDispatch ptr;
    
                    int hr = AccessibleObjectFromWindow(hwndChild, OBJID_NATIVEOM, IID_IDispatch.ToByteArray(), out ptr);
                    if (hr >= 0)
                    {
                        // possibly adjust the name of the property containing the COM  
                        // object accordingly
                        // 
                        wordApp = (Word.Application)ptr.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, ptr, null);
                    }
                }
            }
            return wordApp;
        }
    
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            Process process = Process.Start(@"C:\Program Files (x86)\Microsoft Office\Office12\WINWORD.EXE");
            process.WaitForInputIdle();
            Console.WriteLine("Time to start {0}: {1}", "Word", sw.Elapsed);
            Word.Application wordApp = GetWordApplicationObject(process);
            Console.WriteLine(string.Format("Word version is: {0}", wordApp.Version));
        }
    }
