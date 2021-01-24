    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OverlayForm overlay = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (overlay == null)
            {
                overlay = new OverlayForm(button2.Handle); // <-- pass in an hWnd to some external window
                overlay.Show();
            }  
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (overlay != null)
            {
                overlay.Close();
                overlay = null;
            }
        }
    }
    public class OverlayForm : Form
    {
        private IntPtr ExternalhWnd;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        public OverlayForm(IntPtr ExternalhWnd)
        {
            this.ExternalhWnd = ExternalhWnd;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;        
            this.StartPosition = FormStartPosition.Manual;
            this.Opacity = 0.7; // 70% opacity
            this.BackColor = Color.Yellow;
        }
        protected override CreateParams CreateParams 
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT - Ignore Mouse Clicks
                createParams.ExStyle |= 0x80; // WS_EX_TOOLWINDOW - Remove from Alt-Tab List
                return createParams;
            }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!this.ExternalhWnd.Equals(IntPtr.Zero))
            {
                // position our overlay on top of the external window
                RECT rct;
                GetWindowRect(this.ExternalhWnd, out rct);
                this.Location = new Point(rct.Left, rct.Top);
                this.Size = new Size(rct.Right - rct.Left, rct.Bottom - rct.Top);
            }
        }
    }
