    /// <summary>
    /// Single thread timer class.
    /// </summary>
    public class SingleThreadTimer: IDisposable
    {
        private readonly Timer timer;
        private readonly Action timerAction;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleThreadTimer"/> class.
        /// </summary>
        /// <param name="interval">The interval time.</param>
        /// <param name="timerAction">The timer action to execute.</param>
        /// <exception cref="System.ArgumentNullException">timerAction</exception>
        /// <exception cref="System.ArgumentException">interval</exception>
        public SingleThreadTimer(double interval, Action timerAction)
        {
            if (timerAction == null)
                throw new ArgumentNullException("timerAction");
    
            if (interval <= 0)
                throw new ArgumentException(string.Format("Invalid value '{0}' for parameter 'interval'.", interval), "interval");
    
            this.timerAction = timerAction;
    
            this.timer = new Timer(interval)
            {
                AutoReset = false
            };
                
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
    
        public void Dispose()
        {
            if (timer != null)
                timer.Dispose();
        }
    
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                timerAction();
            }
            finally
            {
                // Enable timer again to continue elapsing event.
                timer.Enabled = true;
            }
        }
    }
