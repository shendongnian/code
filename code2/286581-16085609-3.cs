    class ScheduledTask
    {
        internal readonly Action Action;
        internal System.Timers.Timer Timer;
        internal EventHandler TaskComplete;
        public ScheduledTask(Action action, int timeoutMs)
        {
            Action = action;
            Timer = new System.Timers.Timer() { Interval = timeoutMs };
            Timer.Elapsed += TimerElapsed;            
        }
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Timer.Stop();
            Timer.Elapsed -= TimerElapsed;
            Timer = null;
            Action();
            TaskComplete(this, EventArgs.Empty);
        }
    }
