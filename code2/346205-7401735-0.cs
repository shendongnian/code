    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.BackColor = this.TransparencyKey = Color.Fuchsia;
            this.FormBorderStyle = FormBorderStyle.None;
            var timer = new Timer() { Interval = 50, Enabled = true };
            timer.Tick += delegate {
                this.Location = Cursor.Position;
                // this.Invalidate();   // Uncomment if the text should change
            };
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            e.Graphics.DrawString("hello world", this.Font, Brushes.Black, 10, 0);
        }
    }
