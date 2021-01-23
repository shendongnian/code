    /// <summary>
    /// Encapsulates a class performing a certain activity periodically, which can be initiated once
    /// and then permanently shut down, but not paused/resumed. The class owns its own separate
    /// thread, and manages this thread all by itself. The periodic task is executed on this thread.
    /// <para>The chief differences to <see cref="System.Threading.Timer"/> are as follows. This
    /// class will never issue overlapping activities, even if an activity takes much longer than the interval;
    /// the interval is between the end of the previous occurrence of the activity and the start of the next.
    /// The activity is executed on a foreground thread (by default), and thus will complete once started,
    /// unless a catastrophic abort occurs. When shutting down the activity, it's possible to wait until the
    /// last occurrence, if any, has completed fully.</para>
    /// </summary>
    public abstract class Periodic
    {
        private Thread _thread;
        private CancellationTokenSource _cancellation;
        private ManualResetEvent _exited;
        /// <summary>
        /// Override to indicate how long to wait between the call to <see cref="Start"/> and the first occurrence
        /// of the periodic activity.
        /// </summary>
        protected abstract TimeSpan FirstInterval { get; }
        /// <summary>
        /// Override to indicate how long to wait between second and subsequent occurrences of the periodic activity.
        /// </summary>
        protected abstract TimeSpan SubsequentInterval { get; }
        /// <summary>
        /// Override with a method that performs the desired periodic activity. If this method throws an exception
        /// the thread will terminate, but the <see cref="LastActivity"/> will occur nevertheless.
        /// </summary>
        protected abstract void PeriodicActivity();
        /// <summary>
        /// Override with a method that performs an activity on the same thread as <see cref="PeriodicActivity"/> during
        /// shutdown, just before signalling that the shutdown is complete. The default implementation of this method
        /// does nothing. This method is guaranteed to be called during a shutdown, even if the shutdown is due to an
        /// exception propagating outside of <see cref="PeriodicActivity"/>.
        /// </summary>
        protected virtual void LastActivity() { }
        /// <summary>
        /// Returns false before the first call to <see cref="Start"/> and after the first call to <see cref="Shutdown"/>;
        /// true between them.
        /// </summary>
        public bool IsRunning { get { return _cancellation != null && !_cancellation.IsCancellationRequested; } }
        /// <summary>
        /// Schedules the periodic activity to start occurring. This method may only be called once.
        /// </summary>
        /// <param name="backgroundThread">By default (false) the class will use a foreground thread, preventing application shutdown until the thread has terminated. If true, a background thread will be created instead.</param>
        public virtual void Start(bool backgroundThread = false)
        {
            if (_thread != null)
                throw new InvalidOperationException(string.Format("\"Start\" called multiple times ({0})", GetType().Name));
            _exited = new ManualResetEvent(false);
            _cancellation = new CancellationTokenSource();
            _thread = new Thread(threadProc) { IsBackground = backgroundThread };
            _thread.Start();
        }
        private volatile bool _periodicActivityRunning = false;
        /// <summary>
        /// Causes the periodic activity to stop occurring. If called while the activity is being performed,
        /// will wait until the activity has completed before returning. Ensures that <see cref="IsRunning"/>
        /// is false once this method returns.
        /// </summary>
        public virtual bool Shutdown(bool waitForExit)
        {
            if (waitForExit && _periodicActivityRunning && Thread.CurrentThread.ManagedThreadId == _thread.ManagedThreadId)
                throw new InvalidOperationException("Cannot call Shutdown(true) from within PeriodicActivity() on the same thread (this would cause a deadlock).");
            if (_cancellation == null || _cancellation.IsCancellationRequested)
                return false;
            _cancellation.Cancel();
            if (waitForExit)
                _exited.WaitOne();
            return true;
        }
        private void threadProc()
        {
            try
            {
                _cancellation.Token.WaitHandle.WaitOne(FirstInterval);
                while (!_cancellation.IsCancellationRequested)
                {
                    _periodicActivityRunning = true;
                    PeriodicActivity();
                    _periodicActivityRunning = false;
                    _cancellation.Token.WaitHandle.WaitOne(SubsequentInterval);
                }
            }
            finally
            {
                try { LastActivity(); }
                finally { _exited.Set(); }
            }
        }
    }
    /// <summary>
    /// <para>Encapsulates a class performing multiple related yet independent tasks on the same thread
    /// at a certain minimum interval each. Schedules the activity that is the most late at every opportunity,
    /// but will never execute more than one activity at a time (as they all share the same thread).</para>
    /// </summary>
    public abstract class PeriodicMultiple : Periodic
    {
        /// <summary>
        /// Used to define the activities to be executed periodically.
        /// </summary>
        protected sealed class Task
        {
            /// <summary>The activity to be performed.</summary>
            public Action Action;
            /// <summary>The mimimum interval at which this activity should be repeated. May be delayed arbitrarily though.</summary>
            public TimeSpan MinInterval;
            /// <summary>Stores the last time this activity was executed.</summary>
            public DateTime LastExecuted;
            /// <summary>Calculates by how much this activity has been delayed. Is used internally to pick the next activity to run. Returns negative values for activities that aren't due yet.</summary>
            public TimeSpan DelayedBy()
            {
                if (LastExecuted == default(DateTime))
                    return TimeSpan.FromDays(1000) - MinInterval; // to run shortest interval first when none of the tasks have ever executed
                else
                    return (DateTime.UtcNow - LastExecuted) - MinInterval;
            }
        }
        /// <summary>If desired, override to provide a custom interval at which the scheduler
        /// should re-check whether any activity is due to start. Defaults to 1 second.</summary>
        protected override TimeSpan SubsequentInterval { get { return TimeSpan.FromSeconds(1); } }
        /// <summary>Initialise this with the list of activities to be executed.</summary>
        protected IList<Task> Tasks;
        /// <summary>For internal use.</summary>
        protected sealed override void PeriodicActivity()
        {
            TimeSpan maxDelay = TimeSpan.MinValue;
            Task maxDelayTask = null;
            foreach (var task in Tasks)
            {
                var delayedBy = task.DelayedBy();
                if (maxDelay < delayedBy && delayedBy > TimeSpan.Zero)
                {
                    maxDelay = delayedBy;
                    maxDelayTask = task;
                }
            }
            if (maxDelayTask != null)
            {
                maxDelayTask.LastExecuted = DateTime.UtcNow;
                maxDelayTask.Action();
            }
        }
    }
