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
That's all you need to manage the nuts and bolts of this:
* Record the time when someone clicks start
* When someone clicks stop, do the current time minus the start time and get the totalseconds out of the resulting timespan. Mark the stopwatch as not running so if they click stop again it doesnt add again
* Store those seconds into the settings save (note: must be user scope setting, should be double type)
* If they quit the app while the timer is running, stop the timer, add the seconds, save the settings, close the app
Provide a reset mechanism
