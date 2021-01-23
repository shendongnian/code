    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.AutoScroll = true;
            this.AutoScrollMinSize = new Size(3000, 1000);
            this.ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            e.Graphics.DrawLine(Pens.Black, 0, 0, 3000, 1000);
            base.OnPaint(e);
        }
    }
