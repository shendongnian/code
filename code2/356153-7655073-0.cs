    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e) {
            string text = "Vertical text";
            SizeF textSize = e.Graphics.MeasureString(text, this.Font);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString(text, this.Font, Brushes.Black,
                new PointF(-textSize.Width, 0));
        }
    }
