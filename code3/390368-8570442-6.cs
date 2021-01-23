    using System.Timers;
   
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Text = "Form1";
        Timer timer = new Timer();
        timer.Interval = 5000;
        timer.Start();
        timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
    }
    void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        // put your code here to read the COM port
    }
