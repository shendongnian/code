        private DispatcherTimer remainTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            remainTimer.Tick += MyMethod;
            remainTimer.Interval = TimeSpan.FromSeconds(5);
            remainTimer.Start();
        }
        private void MyMethod(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
            TimeSpan duration = SetDate - DateTime.Now;
            int days = duration.Days + 1;
            string strDays = days.ToString();
            string LeftorAgo = "";
            if (strDays[0] == '-')
            {
                LeftorAgo = "ago";
            }
            else
            {
                LeftorAgo = "left";
            }
            ShowDate.Text = $"{strDays.TrimStart('-')}\n days {LeftorAgo}";
            ShowSubject.Text = Subject;
        }
