 public partial class App : Application
    {
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        static Mutex muetx = new Mutex(true, "{666666666}");
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            if (muetx.WaitOne(TimeSpan.Zero, true))
            {
                TestBeginInvoke.App app = new TestBeginInvoke.App();
                app.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
                app.Run();
            }
            else
            {
                var pro = System.Diagnostics.Process.GetProcessesByName(nameof(TestBeginInvoke));
                var handle = pro.FirstOrDefault().MainWindowHandle;
                ShowWindow(handle, 1);
                ShowWindow(handle, 9);
                SetForegroundWindow(handle);
            }
        }
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
    }
