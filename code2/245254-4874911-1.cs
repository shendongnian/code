    public partial class MovieControl : UserControl
    {
        // PictureBox and Timer added in designer!
        public MovieControl()
        {
            InitializeComponent();
        }
        public void CreateMovie(int i)
        {
            pictureBox1.ImageLocation = "1.png";
            pictureBox1.Location = new Point(50, 50 + (i - 1) * 50);
            // set Interval BEFORE starting timer!
            timer1.Interval = 15;
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            // some code. this part work outside 
        }
    }
