    private System.Timers.Timer t = new System.Timers.Timer();
    
    public Form1()
    {
        InitializeComponent();
    
        t.Elapsed += T_Elapsed;
        t.Interval = int.Parse(textBox1.Text);
        t.AutoReset = false;
        t.Start();
    }
    
    private void T_Elapsed(object sender, EventArgs e)
    {
        this.Invoke((Action)(() => // You can use `BeginInvoke()` as well
        {
            this.Close();
        }));
        // Or
        // this.Invoke(new Action(() => // You can use `BeginInvoke()` as well
        // {
        //     this.Close();
        // }));
    }
