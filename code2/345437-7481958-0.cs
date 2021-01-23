    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bckMap = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            bckMap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bckMap))
            {
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, bckMap.Width, bckMap.Height));
                g.Dispose();
            }
            pictureBox1.BackgroundImage = bckMap;
                
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap ellips = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(ellips))
            {
                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(0, 0, ellips.Width, ellips.Height));
                g.Dispose();
            }
            this.pictureBox1.Image = ellips;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bitmap ellips = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(ellips))
            {
                g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(5, 5, ellips.Width-10, ellips.Height-10));
                g.Dispose();
            }
            this.pictureBox1.Image = ellips;
        }
