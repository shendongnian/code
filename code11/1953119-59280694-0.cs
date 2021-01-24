cs
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
        string AppName;
        public static UInt32 WM_COPYDATA = 0x004A;
        public MainWindow()
        {
            InitializeComponent();
            AppName = this.Title;
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg != WM_COPYDATA) return IntPtr.Zero;
            if (wParam == IntPtr.Zero)
            {
                COPYDATASTRUCT cd = new COPYDATASTRUCT();
                cd = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT));
                MessageBox.Show(cd.lpData);
                DisplaySucceedOrNot.Text = cd.lpData;
            }
            return IntPtr.Zero;
        }
        private void CreateNewProcess_Click(object sender, RoutedEventArgs e)
        {
            if (Process.GetProcessesByName(AppName).Length > 1)
            {
                MessageBox.Show("Already 2 Process Exist.");
                return;
            }
            var path = (System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            Process p = new Process();
            p.StartInfo.FileName = path;
            p.Start();
        }
        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            foreach (var p in Process.GetProcessesByName(AppName))
            {
                if (p.MainWindowHandle == Process.GetCurrentProcess().MainWindowHandle) continue;
                {
                    IntPtr lpData = Marshal.StringToHGlobalAnsi("Hi, Im Sender");
                    COPYDATASTRUCT cd = new COPYDATASTRUCT();
                    cd.lpData = "Hi, Im Sender";
                    cd.dwData = p.MainWindowHandle;
                    cd.cbData = cd.lpData.Length+1;
                    MessageBox.Show(cd.lpData);
                    DisplayAnotherProcessHandle.Text = p.MainWindowHandle.ToString();
                    SendMessage(p.MainWindowHandle, WM_COPYDATA, IntPtr.Zero, ref cd);
                }
            }
        }
        private void AddHandler_Click(object sender, RoutedEventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(Process.GetCurrentProcess().MainWindowHandle);
            source.AddHook(new HwndSourceHook(WndProc));
            DisplayMyProcessHandle.Text = Process.GetCurrentProcess().MainWindowHandle.ToString();
        }
  [1]: https://i.stack.imgur.com/25RiH.png
