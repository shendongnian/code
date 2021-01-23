        public class DisposableTimer : System.Timers.Timer {
        
        /// <summary>
        ///     override the Timer base class Enabled property
        /// </summary>
        /// <remarks>
        ///     the code in the Elapsed event should only be executed when the Enabled property is set to "true".
        ///     we cannot prevent that the Elapsed event is fired at the start, because its automatically put in the ThreadPool,
        ///     but we can prevent that the code in it can be executed when the Enabled property is "false".
        /// </remarks>
        private bool enabled;
        public new bool Enabled 
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = base.Enabled = value;
            }
        }
        /// <summary>
        ///     count the heartbeats
        /// </summary>
        public int HeartbeatCounter { get; set; }
        /// <summary>
        ///     name of timer
        /// </summary>
        public string TimerName { get; set; }
        /// <summary>
        ///     show heartbeat on console
        /// </summary>
        public bool ShowHeartBeat { get; set; }
        // type of entry in eventlog
        public EventLogEntryType EventLogEntryType { get; set; }
        // updated interval to process messages
        public Func<double> UpdatebleInterval { get; set; }
        /// <summary>
        ///     used eventlog
        /// </summary>
        public EventLog EventLog { get; set; }
        /// <summary>
        ///     message logging 
        /// </summary>
        /// <remarks>
        ///     this property needs to be dynamic because in 
        ///     pda service a different class is used but luckily :-)
        ///     with the same method for adding loggings.
        /// </remarks>
        public dynamic MessageLogging { get; set; }
        /// <summary>
        ///     make sure there are no overlapping set of timer callbacks
        /// </summary>
        private object locker; 
        /// <summary>
        ///     initialize timer class
        /// </summary>
        /// <param name="actions">action to perform</param>
        /// <param name="timerName">name of timer</param>
        public DisposableTimer(List<Action> actions, string timerName) : base() 
        {
            // used to make sure there are no overlapping executing sets of timer callbacks
            locker = new object();
            // wrapper for the actions that need to be performed.
            base.Elapsed += (s, a) => Callback(actions);
            // set name of timer
            this.TimerName = timerName;
            /* 
             * only once a callback is executed after elapsed time,
             * because there is only one callback executed there can be
             * no overlap, because the "reset" is done after the set of
             * callbacks are executed.
             */
            AutoReset = false;
            // timer is not started yet
            Enabled = false;
        }
        /// <summary>
        ///     check if verwijder bericht timer is disposed
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                var timerType = typeof(System.Timers.Timer);
                var timerDisposedField = timerType.GetField("disposed", BindingFlags.NonPublic | BindingFlags.Instance);
                return (bool)timerDisposedField.GetValue(this);
            }
        }
        /// <summary>
        ///     after a callback a timer needs to be reset to continue running if AutoReset=false.
        /// </summary>
        /// <param name="interval">new interval of timer</param>
        private void Reset(double interval)
        {
            // stop the timer
            Stop();
            // only do when not disposed yet.
            if (!IsDisposed)
            {
                // adjust interval if needed
                if (interval != 0)
                    Interval = interval;
                // release exclusive lock
                Monitor.Exit(locker);
            }
            // start the timer again
            Start();
        }
        /// <summary>
        ///     only start if not disposed and started yet
        /// </summary>
        public new void Start()
        {
            if (!IsDisposed && !Enabled)
                Enabled = true;
        }
        /// <summary>
        ///     only stop if not disposed and stopped yet
        /// </summary>
        public new void Stop()
        {
            if (!IsDisposed && Enabled)
                Enabled = false;
        }
        /// <summary>
        ///     set of callbacks to perform after timer elapse interval
        /// </summary>
        /// <param name="callBackActions">list of callbacks inside this wrapper to execute</param>
        public void Callback(List<Action> callBackActions)
        {
            // only execute callbacks if timer is enabled.
            if (Enabled)
            {
                /*
                 * AutoReset = false, so a callback is only executed once,
                 * because of this overlapping callbacks should not occur,
                 * but to be sure exclusive locking is also used.
                 */
                var hasLock = false;
                // show heartbeat at output window
                if (ShowHeartBeat)
                    Debug.WriteLine(string.Format("HeartBeat interval: {0}...{1}/thread: 0x{2:X4}", TimerName, ++HeartbeatCounter, AppDomain.GetCurrentThreadId() ));
                // execute callback action.
                try
                {
                    // only perform set of actions if not executing already on this thread.
                    Monitor.TryEnter(locker, ref hasLock);
                    if (hasLock)
                    {
                        // show heartbeat at output window
                        if (ShowHeartBeat)
                            Debug.WriteLine(string.Format("            action: {0}...{1}/thread: 0x{2:X4}", TimerName, HeartbeatCounter, AppDomain.GetCurrentThreadId()));
                        // execute the set of callback actions
                        foreach (Action callBackAction in callBackActions)
                        {
                            // execute callback 
                            try
                            {
                                callBackAction();
                            }
                            // log error, but keep the action loop going.
                            catch (Exception ex)
                            {
                                EventLog.WriteEntry(ex.Message, EventLogEntryType.Warning);
                                MessageLogging.Insert(ex.Message);
                            }
                        }
                    }
                    // show that action is busy
                    else if (ShowHeartBeat)
                        Debug.WriteLine(string.Format("              busy: {0}...{1}/thread: 0x{2:X4}", TimerName, HeartbeatCounter, AppDomain.GetCurrentThreadId()));
                }
                // adjust interval when needed and release exclusive lock when done.
                finally
                {
                    // after the complete action is finished the lock should be released.
                    if (hasLock)
                    {
                        // timer interval can be changed when timer is active, callback function is needed for this.
                        double newInterval = 0;
                        if (UpdatebleInterval != null)
                        {
                            // calculate new interval for timer
                            double updatedInterval = UpdatebleInterval();
                            if (Interval != updatedInterval)
                            {
                                // based on Dutch
                                var dutchCultureInfo = new CultureInfo("nl-NL", false).TextInfo;
                                // write interval change to loggings
                                string intervalMessage = dutchCultureInfo.ToTitleCase(string.Format(@"{0} interval veranderd van {1} naar {2} seconden", TimerName, Interval / 1000, updatedInterval / 1000));
                                EventLog.WriteEntry(intervalMessage, EventLogEntryType.Information);
                                MessageLogging.Insert(intervalMessage);
                                // set for new interval
                                newInterval = updatedInterval;
                            }
                        }
                        // make ready for new callback after elapsed time, lock can be released by now.
                        Reset(newInterval);
                    }
                }
            }
            // show heartbeat at output window
            else if (ShowHeartBeat)
                Debug.WriteLine(string.Format("HeartBeat thread: {0}...{1}/thread: 0x{2:X4}", TimerName, ++HeartbeatCounter, AppDomain.GetCurrentThreadId()));
        }
    }
