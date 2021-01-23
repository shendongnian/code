    public partial class Form1 : Form
    {
        private enum GWL : int
        {
            ExStyle = -20
        }
        private enum WS_EX : int
        {
            Transparent = 0x20,
            Layered = 0x80000
        }
        public enum LWA : int
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        const int WS_EX_NOACTIVATE = 0x08000000;
        const int WS_EX_TOPMOST = 0x00000008;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_TOPMOST; // make the form topmost
                param.ExStyle |= WS_EX_NOACTIVATE; // prevent the form from being activated
                return param;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Prevent form from showing up in taskbar which also prevents activation by Alt+Tab 
            this.ShowInTaskbar = false;
            // Allow the form to be clicked through so that the message never physically interferes with work being done on the computer 
            SetWindowLong(this.Handle, (int)GWL.ExStyle, (int)WS_EX.Layered | (int)WS_EX.Transparent);
            // Set the opacity of the form
            byte nOpacity = 255;    // 0 = invisible, 255 = solid, anything inbetween will show the form with transparency
            SetLayeredWindowAttributes(this.Handle, 0, nOpacity, (uint)LWA.Alpha);
        }
    }
