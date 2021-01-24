    public partial class Window1 : Window
    {
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private readonly Queue<Point> _locations = new Queue<Point>();
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, UIntPtr dwExtraInfo);
        public Window1()
        {
            InitializeComponent();
            LocationChanged += Window_LocationChanged;
        }
        private bool _handle = true;
        private void Window_LocationChanged(object sender, EventArgs e)
        {
            if (_handle && Left < 100 && Top < 100)
            {
                _handle = false;
                mouse_event(MOUSEEVENTF_LEFTUP, 50, 50, 0, UIntPtr.Zero);
                Top = 0;
                Left = 0;
                _handle = true;
            }
        }
    }
