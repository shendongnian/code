    public Form1()
        {
            InitializeComponent();
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            this.Invalidate();
        }
