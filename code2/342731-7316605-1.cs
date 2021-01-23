    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, 
            IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", 
            CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr WindowFromPoint(Point point);
        private const int BM_CLICK = 0x00F5;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Specify the point you want to click
            var screenPoint = this.PointToScreen(new Point(button2.Left, 
                button2.Top));
            // Get a handle
            var handle = WindowFromPoint(screenPoint);
            // Send the click message
            if (handle != IntPtr.Zero)
            {
                SendMessage( handle, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi", "There");
        }
    }
