    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass();
            myClass.Install();
            Application.Run(new Form()); // You need a form, not sure why.
            myClass.Uninstall();
        }
    }
    public class MyClass : CriticalFinalizerObject
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(HookType idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId); 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk); 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam); 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);
        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        private enum HookType : int
        {
            WH_KEYBOARD = 2,
            WH_KEYBOARD_LL = 13
        }
        private enum WindowsMessage : int
        {
            WM_KEYUP = 0x101
        }
        private HookProc _myCallbackDelegate;
        private IntPtr _hook;
        public MyClass()
        {
            _myCallbackDelegate = MyCallbackFunction;
        }
        public void Install()
        {
            Uninstall();
            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                _hook = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _myCallbackDelegate, GetModuleHandle(module.ModuleName), 0);
            }
        }
        public void Uninstall()
        {
            var ptr = Interlocked.Exchange(ref _hook, IntPtr.Zero);
            if (ptr != IntPtr.Zero)
                UnhookWindowsHookEx(ptr);
        }
        private IntPtr MyCallbackFunction(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WindowsMessage.WM_KEYUP)
            {
                var sk = Marshal.ReadInt32(lParam);
                // This can be used to find the scancode.
                // Press the key and watch the console to find out the scancode.
                Console.WriteLine("ScanCode: 0x{0:x4}", sk);
                if (sk == 0x0041) // 0x0041 is A
                {
                    // We can't hold up the hook for too long; start the
                    // tray open on another thread.
                    new Action(OpenTray).BeginInvoke(null, null);
                }
            }
            return CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }
        private void OpenTray()
        {
            mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
        }
        ~MyClass()
        {
            Uninstall();
        }
    }
