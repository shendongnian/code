        public Form1()
        {
            InitializeComponent();
            t.Tick +=new EventHandler(t_Tick);
            t.Interval = 500;
        }
        int timeElapsed = 0;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();
            ThreadPool.QueueUserWorkItem((x) =>
            {
                TimeConsumingFunction();
            });
        }
        void TimeConsumingFunction()
        {
            Thread.Sleep(10000);
            t.Stop();
        }
        void t_Tick(object sender, EventArgs e)
        {
            timeElapsed += t.Interval;
            label1.Text = timeElapsed.ToString();
        }
