private DateTime _startTime = DateTime.MinValue;
public Form1()
{
        InitializeComponent();
}
private void Start_Click(object sender, EventArgs e)
{
        _startTime = DateTime.UtcNow;
}
private void Stop_Click(object sender, EventArgs e)
{
        StopStopwatch(true);
}
private void StopStopwatch(bool showErrorMessages)
{
        if(_startTime > DateTime.MinValue)
            Properties.Settings.Default.ElapsedTotalSeconds += (DateTime.UtcNow - _startTIme).TotalSeconds;
        else if(showErrormessages)
            MessageBox.Show("Stopwatch isn't running");
          
        _startTIme = DateTime.MinValue; //if minvalue it means the stopwatch isn't running
}
private void Reset_Click(object sender, EventArgs e)
{
        Properties.Settings.Default.ElapsedTotalSeconds = 0;
}        
private void Form1_FormClosed(object sender, FormClosedEventArgs e)
{
        StopStopwatch(false);
        Properties.Settings.Default.Save();
}
//if you want a visual feedback the timer is running, have a timer that you start and stop with the click events, and update a label in its tick event
private void Timer_Tick(...) //its a windows forms timer, not a system timers timer
{
        if(_startTIme > DateTime.MinValue){
          TimeSpan ts = TimeSpan.FromSeconds(Properties.Settings.Default.ElapsedTotalSeconds);
          ts += (DateTime.UtcNow - _startTime);
          Label1.Text = ts.ToString();
        }
}
That's all you need to manage the nuts and bolts of this:
* Record the time when someone clicks start
* When someone clicks stop, do the current time minus the start time and get the totalseconds out of the resulting timespan. Mark the stopwatch as not running so if they click stop again it doesnt add again
* Store those seconds into the settings save (note: must be user scope setting, should be double type)
* If they quit the app while the timer is running, stop the timer, add the seconds, save the settings, close the app
Provide a reset mechanism.
If you want some sort of visual feedback the timer is running, see the bottom of the code - it's a timer that will repeatedly update a label with the current total time derived from a TimeSpan based on the Settings value, plus a TimeSpan based on the difference between when start was clicked, and now. The label will update every time the timer tiks. If you want tit to update 10 times a second, make the timer interval 100ms 
