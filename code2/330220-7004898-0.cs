    public partial class TimerUserControl : UserControl
    {
        public event TimerExpiredEventHandler Expired;
        public void OnExpired(EventArgs e)
        {
            if (Expired != null)
                Expired(this, e);
        }
    public void timerSecondsLeft_Tick(object sender, EventArgs e)
    {
        _secondsRemaining--;
        if (_secondsRemaining <= 0)
        {
            timerSecondsLeft.Stop();
            TimesUp = true;
            TimeTextBlock.Text = "Time's up. Press Enter to next problem.";
            // Fire the event here.
            OnExpired(EventArgs.Empty);
        }
        else
        {
            TimeTextBlock.Text = string.Format("It remains {0} seconds. Don't take long!", _secondsRemaining);
        }
    }
    }
