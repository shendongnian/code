    using System.Timers;
   
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Form1";
        Timer timer = new Timer();
        timer.Interval = 5000;
        timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        //timer.Enabled = true; // you may need this, but probably not if you are calling the start method.
        timer.Start();
    }
    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        // put your code here to read the COM port
    }
