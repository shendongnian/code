    public partial class MainWindow  {
        public MainWindow() {
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e) {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(this.WindowProc));
        }
        private const int WM_SIZING = 0x0214;
        private const int WM_EXITSIZEMOVE = 0x0232;
        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            switch (msg) {
                case WM_SIZING:
                    this.firstColumn.ClearValue(ColumnDefinition.MinWidthProperty);
                    break;
                case WM_EXITSIZEMOVE:
                    this.firstColumn.MinWidth = this.firstColumn.ActualWidth;
                    this.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
                    break;
            }
            return IntPtr.Zero;
        }
    }
