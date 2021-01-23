    public partial class UserControl1 : PictureBox 
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private bool shifted = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.Image != null)
            {
                this.shifted = true;
                this.Invalidate();
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.Image != null)
            {
                this.shifted = false;
                this.Invalidate();
            }
            base.OnMouseUp(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (this.shifted)
            {
                pe.Graphics.TranslateTransform(3, 3, System.Drawing.Drawing2D.MatrixOrder.Append);
            }
            base.OnPaint(pe);
        }
    }
