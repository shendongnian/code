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
                if (this.Image != null)
                {
                    pe.Graphics.DrawImage(this.Image, new Point(3, 3));
                }
            }
            else
            {
                base.OnPaint(pe);
            }
        }
    }
