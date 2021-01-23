    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            var _Control = (sender as System.Windows.Controls.Border);
            var _ControlLocation = _Control.PointToScreen(new Point(0, 0));
            var _MousePosition = MouseInfo.GetMousePosition();
            var _RelativeLocation = _MousePosition - _ControlLocation;
            this.Jerry.Text = _RelativeLocation.ToString();
        }
    }
    internal class MouseInfo
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(
            System.Runtime.InteropServices.UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);
        [System.Runtime.InteropServices.StructLayout(
            System.Runtime.InteropServices.LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
    }
