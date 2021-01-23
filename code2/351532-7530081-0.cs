    public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer timer = newSystem.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }
        void Timer_Tick(object sender, EventArgs e)
        {
            //
        }
