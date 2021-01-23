    public class TimerWrapper
    {
        private object defaultLock = new object();
        private object functionLock = null;
        private object classLock = new object();
        protected bool isRunning = false;
        protected bool isRepeating = false;
        protected Timer timer = null;
        protected Action timerFn = null;
        public TimerWrapper(Action timerFn)
        {
            if (timerFn == null)
            {
                throw new ArgumentNullException("timerFn", "Invalid timer delegate supplied at construction");
            }
            // Execute this function upon expiration of the timer
            this.timerFn = timerFn;
        }
        public TimerWrapper(Action timerFn, ref object timerLock) : this(timerFn)
        {
            // Use the locking object passed at construction
            this.functionLock = timerLock;
        }
        protected void TimerFunction(object state)
        {
            if (timerFn != null)
            {
                lock (classLock)
                {
                    // Lock on function lock if available or default lock otherwise
                    lock (functionLock ?? defaultLock)
                    {
                        // If timer isn't repeating it's now no longer running
                        if (!IsRepeating)
                        {
                            IsRunning = false;
                        }
                        // Execute this function because timer has expired
                        timerFn();
                    }
                }
            }
        }
        public void Stop()
        {
            lock (classLock)
            {
                if (timer != null)
                {
                    timer.Dispose();
                    timer = null;
                }
                IsRunning = false;
            }
        }
        public void Start(int duetime)
        {
            // Start the timer for a single run
            Start(duetime, Timeout.Infinite);
        }
        public void Start(int duetime, int period)
        {
            if (duetime > 0)
            {
                lock (classLock)
                {
                    // Stop the timer
                    Stop();
                    // Start the timer for either a single run or repeated runs
                    timer = new Timer(TimerFunction, null, duetime, period);
                    IsRunning = true;
                    IsRepeating = (period != Timeout.Infinite);
                }
            }
        }
        public bool IsRepeating
        {
            get
            {
                return isRepeating;
            }
            protected set
            {
                if (isRepeating != value)
                {
                    isRepeating = value;
                }
            }
        }
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            protected set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                }
            }
        }
    }
