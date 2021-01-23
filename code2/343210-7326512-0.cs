    public partial class MainForm : Form
    {
        private bool m_Running;
        public MainForm()
        {
            InitializeComponent();
            DuplicateForm f2 = new DuplicateForm(this.Text);
            f2.Show();
            
            m_Running = true;
            Thread t = new Thread(new ThreadStart(() =>
                {
                    while (m_Running)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                          Bitmap bm = new Bitmap(Width, Height);
                          // pnl is a Panel with Dock=Fill
                          pnl.DrawToBitmap(bm, new Rectangle(0, 0, Width, Height));
                          f2.SetImage(this, bm);
                         }));
                        Thread.Sleep(500); // or use a timer
                    }
                }));
            t.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_Running = false;
        }
    }
    public partial class DuplicateForm : Form
    {
        public DuplicateForm(string title)
        {
            InitializeComponent();
            Text = title + " [copy]";
        }
        public void SetImage(Form source, Image img)
        {
            this.Size = source.Size;
            // Picturebox is a PictureBox control with Dock=Fill
            pictureBox1.Image = img;
        }
    }
