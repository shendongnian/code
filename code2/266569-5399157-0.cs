    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            pictureBox1.MouseCaptureChanged += new EventHandler(pictureBox1_MouseCaptureChanged);
            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
            button1.Click += new EventHandler(button1_Click);
        }
        private void button1_Click(object sender, EventArgs e) {
            var rc = pictureBox1.RectangleToScreen(new Rectangle(Point.Empty, pictureBox1.ClientSize));
            Cursor.Position = new Point(rc.Left + rc.Width / 2, rc.Top + rc.Height / 2);
            Cursor.Clip = rc;
            pictureBox1.Capture = true;
            pictureBox1.Cursor = Cursors.Cross;
        }
        void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            pictureBox1.Capture = false;
        }
        void pictureBox1_MouseCaptureChanged(object sender, EventArgs e) {
            if (!pictureBox1.Capture) {
                pictureBox1.Cursor = Cursors.Default;
                Cursor.Clip = new Rectangle(0, 0, 0, 0);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Escape) pictureBox1.Capture = false;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
