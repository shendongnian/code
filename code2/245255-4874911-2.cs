    class Form1
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MovieControl mc = new MovieControl();
            mc.CreateMovie(1);
            this.Controls.Add(mc); /// VITAL!!
        }
    }
