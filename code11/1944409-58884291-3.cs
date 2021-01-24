public class Reminder{
    private Timer _t = new Timer();
    private string _reminderText = "Remember remember!";
    private string _reminderDate = new DateTime(2019, 11, 16, 12, 34, 56); //12:34:56 on 16 nov 2019
    public Reminder(){ //constructor
        _t.Tick += TimerTick;
        _t.Interval = 60000;//60 seconds
    }
    private void TimerTick(Object sender, EventArgs e){
        if(DateTime.Now > _reminderDate)
        {
            _t.Stop();
            MessageBox.Show(_reminderText);
          
        }
    }
    private void RemindButton_Click(object sender, EventArgs e){
        //add code in here to set the _reminderText, _reminderDate, and finally Start() the timer
    }
}
I'll leave it as an exercise for you to set the reminderText (you already have it as FinalMessage) and _reminderDate (some parsing of your inputs will be required, remember to make it a date in the future, as this is how our logic succeeds (if the time is in the past, the message will show immediately). After you set these things, start the timer
If you want a recurring reminder, instead of stopping the timer, rearrange the _reminderDate for another future date (tomorrow at the same time, for example)
Christopher comments that we could set the timer so it triggers on the reminder date - seems a reasonable alternative: Calculate the number of milliseconds between the reminder date and now, and set the Timer's interval to that..
If you have a timer that fires regularly, you could update the UI to provide a countdown in minutes until the next reminder - what you code very much depends on what you want to do
