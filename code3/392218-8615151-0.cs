    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Resize += new EventHandler(Form1_Resize);
        }
        void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate(true);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Red, 2.0f))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, ClientSize.Width-1, ClientSize.Height-1));
            }
        }
    }
