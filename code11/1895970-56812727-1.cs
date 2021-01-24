     using Timer = System.Windows.Forms.Timer;
     private void Form1_Load(object sender, EventArgs e)
    {
        Timer MyTimer = new Timer();
        MyTimer.Interval = (45 * 60 * 1000); // 45 mins
        MyTimer.Tick += new EventHandler(MyTimer_Tick);
        MyTimer.Start();
    }
    private void MyTimer_Tick(object sender, EventArgs e)
    {
        //Check for internet connection or some other work here
        Timer MyTimer = new Timer();
        MyTimer.Interval = (45 * 60 * 1000); // 45 mins
        MyTimer.Tick += new EventHandler(MyTimer_Tick);
        MyTimer.Start();
    }
