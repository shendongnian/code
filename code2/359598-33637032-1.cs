    public partial class Form1 : Form
    {
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
        [DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        private const int WM_ACTIVATE = 6;
        private const int WA_INACTIVE = 0;
        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATEANDEAT = 0x0004;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)MA_NOACTIVATEANDEAT; // prevent the form from being clicked and gaining focus
                return;
            }
            if (m.Msg == WM_ACTIVATE) // if a message gets through to activate the form somehow
            {
                if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
                {
                    if (m.LParam != IntPtr.Zero)
                    {
                        SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        // Could not find sender, just in-activate it.
                        SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            else
            {
                base.WndProc(ref m);
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
        }
    }
