public class Form1: Form
{
    public System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
    public Form1()
    {
         InitializeComponent();
        
        // Create a timer and set a two second interval.
        aTimer.Interval = 2000;
        // Hook up the tick event for the timer. 
        aTimer.Tick += OnTimedEvent;
        // Have the timer fire repeated events (true is the default)
        aTimer.AutoReset = true;
        // Start the timer
        aTimer.Enabled = true;
        Console.WriteLine("Press the Enter key to exit the program at any time... ");
        Console.ReadLine();
    }
    private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        // update your statistics here
    }
}
If you want to update the ui there, then the tick event is the way to go: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.timer.tick?view=netframework-4.8
