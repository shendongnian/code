    [DefaultEvent("Tick")]
    public class ThreadUISafeTimer : Component
    {
        private const int True = 1;
        private const int False = 0;
        private int enabled = False;
        private SynchronizationContext context;
        public event EventHandler Tick = delegate { };
        [DefaultValue(false)]
        public ushort Interval { get; set; }
        public ThreadUISafeTimer() {
            Interval = 100;
            this.Events.AddHandler("Tick", Tick);
            //If this class is created by a UI thread it will always post the Tick event to it.
            //otherwise it would be null and Tick would occur in a seperate thread.
            context = SynchronizationContext.Current;
        }
        protected override bool CanRaiseEvents {
            get {
                return true;
            }
        }
        [DefaultValue(false)]
        public bool Enabled {
            get {
                return enabled == True;
            }
            set {
                int newval = value ? True : False;
                if (enabled != newval) {
                    if (newval == False)
                        Thread.VolatileWrite(ref enabled, False);
                    else {
                        enabled = True;
                        ThreadPool.QueueUserWorkItem(
                            new WaitCallback(delegate(object o) {
                            try {
                                do {
                                    try {
                                        Thread.Sleep(Interval);
                                        if (Thread.VolatileRead(ref enabled) == True) {
                                            var callback = new SendOrPostCallback(delegate(object arg) {
                                                try {
                                                    Tick(this, EventArgs.Empty);
                                                }
                                                catch (Exception exp) {
                                                    Application.OnThreadException(exp);
                                                    return;
                                                }
                                            });
                                            //If context is null raise Tick event from current thread
                                            if (context == null)
                                                callback(null);
                                            else
                                                //otherwise post it to the UI thread that owns this timer.
                                                context.Post(callback, null);
                                        }
                                    }
                                    catch (ThreadInterruptedException) {
                                    }
                                } while (Thread.VolatileRead(ref enabled) == True);
                            }
                            catch (ThreadAbortException) {
                            }
                        }), null);
                    }
                }
            }
        }
   
