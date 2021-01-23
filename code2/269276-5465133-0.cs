    public partial class Form1 : Form
    {
        private bool suspendDraw;
        public Form1()
        {
            this.InitializeComponent();
        }
        public void SuspendDraw()
        {
            this.suspendDraw = true;
        }
        public void ResumeDraw()
        {
            this.suspendDraw = false;
        }
        private const int WM_PAINT = 0x000F;
        protected override void WndProc(ref Message m)
        {
            if ((m.Msg != WM_PAINT) || (!this.suspendDraw && m.Msg == WM_PAINT))
            {
                base.WndProc(ref m);
            }
        }
    }
