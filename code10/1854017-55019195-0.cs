        int x = 25, y = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label1.SetBounds(x, y, 255, 255);
            label2.SetBounds(x, 100, 255, 255);
            x++;
            if (x >= 800)
            {
                x = 1;
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            label1.Text = "hii";
            label1.Font = new Font(" ", 22, FontStyle.Bold);
            label2.Text = "hii2";
            label2.Font = new Font(" ", 22, FontStyle.Bold);
            timer1.Interval = 10;
            timer1.Start();
        }
