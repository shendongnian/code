    class Form1{
      public Form1()
      {
        InitializeComponent();
      }
      private void button1_Click(object sender, EventArgs e)
      {
        MovieControl mc = new MovieControl();
        mc.createMove(1);
        this.Controls.Add(mc); /// VITAL!!
      }
    }
    public partial class MovieControl : UserControl
    {
        /// PictureBox and Timer added in designer!
        public MovieControl()
        {
            InitializeComponent();
        }
        public void createMovie(int i)
        {
            pictureBox1.ImageLocation = "1.png";
            pictureBox1.Location = new Point(50, 50 + (i - 1) * 50);
            /// set Interval BEFORE starting timer!
            timer1.Interval = 15;
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        private int k = 0;
        void timer1_Tick(object sender, EventArgs e)
        {
         // some code. this part work outside 
        }
    }
