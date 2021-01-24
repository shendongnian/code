    private void Form1_Load(object sender, EventArgs e)
    {
        // Set the interval to how often you want it to execute
        timer1.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
        // Set a method to run on every interval
        timer1.Tick += Timer1_Tick;
    }
    public void Start_Click(object sender, EventArgs e)
    {
        // start or stop the timer
        timer1.Enabled = !timer1.Enabled;
        // Above we are just flipping the 'Enabled' property, but
        // you could also call timer1.Start() (which is the same as 
        // setting 'Enabled = true') or timer1.Stop() (which is
        // the same as setting 'Enabled = false')
    }
    // Put code in this method that should execute when the timer interval is reached
    private void Timer1_Tick(object sender, EventArgs e)
    {
        var usage = new CpuUsage(); //placeholder class for getting the CPU use data
        usage.setCPU(); //gets a random number
        this.CPU.Text = usage.cpuUsage; //show the usage data on a textbox
    }
