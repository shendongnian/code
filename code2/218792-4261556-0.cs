    public sealed class TimerService : ITimerService
    {
        public void WhenElapsed(TimeSpan duration, Action callback)
        {
            if (callback == null) throw new ArgumentNullException("callback");
            //Set up state to allow cleanup after timer completes
            var timerState = new TimerState(callback);
            var timer = new Timer(OnTimerElapsed, timerState, Timeout.Infinite, Timeout.Infinite);
            timerState.Timer = timer;
            
            //Start the timer
            timer.Change((int) duration.TotalMilliseconds, Timeout.Infinite);
        }
        private void OnTimerElapsed(Object state)
        {
            var timerState = (TimerState)state;
            timerState.Timer.Dispose();
            timerState.Callback();
        }
        private class TimerState
        {
            public Timer Timer { get; set; }
            public Action Callback { get; private set; }
            public TimerState(Action callback)
            {
                Callback = callback;
            }
        }
    }
