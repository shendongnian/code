    private volatile int _counter;
    private readonly Timer _timer = new System.Windows.Forms.Timer();
    public Form1()
    {
    	InitializeComponent();
    
    	_timer.Tick += TimerTick;
    	_timer.Interval = 20;  // ~50 Hz/fps
    	_timer.Start();
    }
    void TimerTick(object sender, EventArgs e)
    {
    	label1.Text = _counter.ToString();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
    	Thread thread = new Thread(CountNumbers) {IsBackground = true};
    	thread.Start(); 
    }
    public void CountNumbers()
    {
    	for (int i = 0; i < 60000; i++)
    	{
    		_counter++;
    		Thread.Sleep(10);  // <-- Simulated work load
    	}
    }
