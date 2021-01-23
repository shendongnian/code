    public partial class UserControl1 : UserControl {
        public UserControl1() {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(1000, 0);
        }
        protected override void OnScroll(ScrollEventArgs se) {
            base.OnScroll(se);
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            e.Graphics.DrawLine(Pens.Black, 0, 0, 1000, this.ClientSize.Height);
            base.OnPaint(e);
        }
    }
