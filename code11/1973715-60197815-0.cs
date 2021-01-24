       private readonly object y = new object();
        int x = 1921;
        public Form1()
        {
            InitializeComponent();
        }
        System.Timers.Timer myTimer = new System.Timers.Timer(1000);
        private void UpdateLabel(object sender, ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)(() => { lock (y) { label1.Text = x.ToString(); x++; } }));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myTimer.Elapsed += UpdateLabel;
            myTimer.Start();
        }
    
