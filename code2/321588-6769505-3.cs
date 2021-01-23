        int value = 10;
        public MainWindow()
        {
            InitializeComponent();
            Feedback.DataContext = value;
            Timer t = new Timer(500);
            t.Elapsed += (s, e) =>
                {
                    if (value > 0) Dispatcher.Invoke(new Action(() => { Feedback.DataContext = --value; }));
                    else t.Stop();
                };
            t.Start();
        }
