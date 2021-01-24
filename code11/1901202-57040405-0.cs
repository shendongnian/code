    public partial class MainWindow : Window
    {
        [DllImport("user32.dll", EntryPoint = "RegisterWindowMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int RegisterWindowMessage(string lpString);
        [DllImport("user32.dll")]
        public static extern bool RegisterShellHookWindow(IntPtr handle);
        private static int _msg;
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            _msg = RegisterWindowMessage("SHELLHOOK");
            RegisterShellHookWindow(handle);
            HwndSource source = HwndSource.FromHwnd(handle);
            source.AddHook(new HwndSourceHook(WndProc));
        }
        private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == _msg)
            {
                switch (wParam.ToInt32())
                {
                    case 1:
                        //window created
                        break;
                    case 2:
                        //window destroyed
                        break;
                }
            }
            return IntPtr.Zero;
        }
    }
