    public partial class Form1 : Form
    {
        private PictureBox box = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            box.Dock = DockStyle.Fill;
            box.BackColor = Color.White;
            box.Paint += new PaintEventHandler(DrawTest);
            this.Controls.Add(box);
        }
        public void DrawTest(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            double value = .5;
            var fs = string.Format("{0:0.0%}", value);
            var font = new Font("Arial", 12);
            var brush = new SolidBrush(Color.Black);
            var point = new PointF(100.0F, 100.0F);
            g.DrawString(fs, font, brush, point);
        }
    }
