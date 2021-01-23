    public partial class Form1 : Form
    {
        Options_c o = new Options_c();
        
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            o.Allow = false;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            o.Allow = true;
            o.X = e.X;
            o.Y = e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (o.Allow == true)
            {
                Graphics g = pictureBox1.CreateGraphics();
                Pen p1 = new Pen(o.color, 5);
                g.DrawLine(p1, o.X,o.Y, e.X, e.Y);
                o.X = e.X;
                o.Y = e.Y;
            }
        }
    }
    class Options_c
    {
        public Boolean Allow = false;
        public Int32 X;
        public Int32 Y;
        public Color color = Color.Bisque;
    }
