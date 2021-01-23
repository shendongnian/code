    private static AutoResetEvent _wait = new AutoResetEvent(false);
    
    public Form1()
        {
            InitializeComponent();
        }
    
    private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.RunWorkerAsync();
        }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Dosomething();
        }
    private void Dosomething()
    {
     //Your Loop
     for(int i =0;i<10;i++)
       {
        //Dosomething
        _wait._wait.WaitOne();//Pause the loop until the button was clicked.
        
       } 
    }
    private void btn1_Click(object sender, EventArgs e)
        {
            _wait.Set();
        }
