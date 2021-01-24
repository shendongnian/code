	public const int WH_MIN = (-1);
    public const int WH_MSGFILTER = (-1);
    public const int WH_JOURNALRECORD = 0;
    public const int WH_JOURNALPLAYBACK = 1;
    public const int WH_KEYBOARD = 2;
    public const int WH_GETMESSAGE = 3;
    public const int WH_CALLWNDPROC = 4;
    public const int WH_CBT = 5;
    public const int WH_SYSMSGFILTER = 6;
    public const int WH_MOUSE = 7;
    public const int WH_HARDWARE = 8;
    public const int WH_DEBUG = 9;
    public const int WH_SHELL = 10;
    public const int WH_FOREGROUNDIDLE = 11;
    public const int WH_CALLWNDPROCRET = 12;
    public const int WH_KEYBOARD_LL = 13;
    public const int WH_MOUSE_LL = 14;
    public const int WH_MAX = 14;
    public const int WH_MINHOOK = WH_MIN;
    public const int WH_MAXHOOK = WH_MAX;
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MSLLHOOKSTRUCT
    {
        public System.Drawing.Point pt;
        public int mouseData;
        public int flags;
        public int time;
        public uint dwExtraInfo;
    }
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct KBDLLHOOKSTRUCT
    {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public uint dwExtraInfo;
    }
    public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern bool UnhookWindowsHookEx(int idHook);
    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
        public POINT(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }
    }
    [DllImport("User32.dll", SetLastError = true)]
    public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);
