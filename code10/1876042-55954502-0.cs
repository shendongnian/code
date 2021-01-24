    public sealed partial class ModalWindow : Window, IDisposable
    {
        [DllImport("User32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookDelegate lpfn, IntPtr hmod, int dwThreadId);
        [DllImport("User32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("User32.dll")]
        public static extern IntPtr UnhookWindowsHookEx(IntPtr hHook);
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }
        public delegate IntPtr HookDelegate(int code, IntPtr wParam, IntPtr lParam);
        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private HookDelegate mouseDelegate;
        private IntPtr mouseHandle;
        public ModalWindow()
        {
            InitializeComponent();
            mouseDelegate = MouseHookDelegate;
            mouseHandle = SetWindowsHookEx(WH_MOUSE_LL, mouseDelegate, IntPtr.Zero, 0);
        }
        private IntPtr MouseHookDelegate(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code < 0)
                return CallNextHookEx(mouseHandle, code, wParam, lParam);
            switch ((int)wParam)
            {
                case WM_LBUTTONDOWN:
                    POINT lpPoint;
                    GetCursorPos(out lpPoint);
                    if (lpPoint.X < Left || lpPoint.X > (Left + Width) || lpPoint.Y < Top || lpPoint.Y > (Top + Height))
                    {
                        //Outside click detected...
                    }
                    break;
            }
            return CallNextHookEx(mouseHandle, code, wParam, lParam);
        }
        protected override void OnClosed(EventArgs e)
        {
            Dispose();
            base.OnClosed(e);
        }
        public void Dispose()
        {
            if (mouseHandle != IntPtr.Zero)
                UnhookWindowsHookEx(mouseHandle);
        }
    }
