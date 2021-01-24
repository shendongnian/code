    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pictureBox1.BackColor=Color.Black;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // The code below will draw on the surface of pictureBox1
            // It gets triggered automatically by Windows, or by
            // calling .Invalidate() or .Refresh() on the picture box.
            DrawGraphics(e.Graphics, pictureBox1.ClientRectangle);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // The code below will draw on an existing image shown in pictureBox2
            var img = new Bitmap(pictureBox2.Image);
            var g = Graphics.FromImage(img);
            DrawGraphics(g, pictureBox2.ClientRectangle);
            pictureBox2.Image=img;
        }
        void DrawGraphics(Graphics g, Rectangle target)
        {
            // draw a red rectangle around the moon 
            g.DrawRectangle(Pens.Red, 130, 69, 8, 8);
        }
    }
