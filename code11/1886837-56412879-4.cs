    private System.Timers.Timer t = new System.Timers.Timer();
    
    public Form1()
    {
        InitializeComponent();
    
        t.Tick += T_Tick;
        t.AutoReset = false;
        t.Start();
    }
    
    private void T_Tick(object sender, EventArgs e)
    {
        this.Invoke((Delegate)(() => // You can use `BeginInvoke()` as well
        {
            this.Close();
        }));
    }
