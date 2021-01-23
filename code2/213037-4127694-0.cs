    using Timer = System.Timers.Timer;
    using Systems.Timers;
    using System.Windows.Forms;//WinForms example
    private static Timer loopTimer;
    private Button formButton;
    public YourForm()
    { 
        //loop timer
        loopTimer = new Timer();
        loopTimer.Interval = 500;/interval in milliseconds
        loopTimer.Enabled = false;
        loopTimer.Elapsed += loopTimerEvent;
        loopTimer.AutoReset = true;
        //form button
        formButton.MouseDown += mouseDownEvent;
        formButton.MouseUp += mouseUpEvent;
    }
    private static void loopTimerEvent(Object source, ElapsedEventArgs e)
    {
        //do whatever you want to happen while clicking on the button
    }
    private static void mouseDownEvent(object sender, MouseEventArgs e)
    {
        loopTimer.Enabled = true;
    }
    private static void mouseUpEvent(object sender, MouseEventArgs e)
    {
        loopTimer.Enabled = false;
    }       
