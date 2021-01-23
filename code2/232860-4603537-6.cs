    private System.Threading.Timer timer = new Timer(_TimerTick, null, 1000 * 30 * 60, Timeout.Infinite);
    private void _OnUserActivity(object sender, EventArgs e)
    {
         if(timer != null)
         {
             // postpone auto-logout by 30 minutes
             timer.Change(1000 * 30 * 60, Timeout.Infinite);
         }
    }
    private void _TimerTick(object state)
    {
        // the user has been inactive for 30 minutes; log him out
    }
