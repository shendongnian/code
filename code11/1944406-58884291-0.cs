public class Reminder{
    private System.Timers.Timer _t = new System.Timers.Timer();
    private string _reminderMessage = "Remember remember!";
    private string _reminderDate = new DateTime(2019, 11, 16, 12, 34, 56); //12:34:56 on 16 nov 2019
    public Reminder(){ //constructor
        _t.Elapsed += TimerElapsed;
        _t.Interval = 60000;//60 seconds
    }
    private void TimerElapsed(Object source, ElapsedEventArgs e){
        if(DateTime.Now > _reminderDate)
        {
            _t.Stop();
            MessageBox.Show(_reminderText);
          
        }
    }
}
I'll leave it as an exercise for you to set the reminderText (you already have it as FinalMessage) and _reminderDate (some parsing of your inputs will be required). After you set these things, start the timer
