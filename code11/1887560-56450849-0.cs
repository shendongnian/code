    public partial class MainWindow : Window
    {
        public static IntPtr _hookID = IntPtr.Zero;
        private static MouseHook.LowLevelMouseProc _proc;
        public MainWindow()
        {
            InitializeComponent();
            _proc = new MouseHook.LowLevelMouseProc(HookCallback);
            _hookID = MouseHook.SetHook(_proc);
        }
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 &&  MouseHook.MouseMessages.WM_MOUSEMOVE == (MouseHook.MouseMessages)wParam)
            {
                MouseHook.MSLLHOOKSTRUCT hookStruct = (MouseHook.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MouseHook.MSLLHOOKSTRUCT));
                if (hookStruct.pt.x < 0)
                {
                    System.Windows.Forms.Cursor.Position = new System.Drawing.Point(0, hookStruct.pt.y);
                    return (IntPtr)1;
                }
            }
            return MouseHook.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
    class MouseHook
    {
        private const int WH_MOUSE_LL = 14;
        public enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        public static IntPtr SetHook(LowLevelMouseProc proc)
        {
            IntPtr hInstance = LoadLibrary("User32");
            return MouseHook.SetWindowsHookEx(WH_MOUSE_LL, proc, hInstance, 0);
        }
    }
