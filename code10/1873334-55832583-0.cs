    public partial class Form1 : Form
    {
        private GraphicsPath path = new GraphicsPath();
        private float scale = 1.0F;
        public Form1()
        {
            InitializeComponent();
            path.AddRectangle(new Rectangle(10, 10, 50, 100));
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            pictureBox1.Paint += pictureBox1_Paint;
        }
        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            scale = Math.Max(scale + Math.Sign(e.Delta) * 0.1F, 0.1F);
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.DrawPath(Pens.Red, path);
        }
    }
