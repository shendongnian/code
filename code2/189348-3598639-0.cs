        public new event ElapsedEventHandler Elapsed;
        private System.Threading.AutoResetEvent m_autoResetEvent = new System.Threading.AutoResetEvent(true);
        public TickableTimer()
            : this(100)
        {
        }
        public TickableTimer(double interval)
            : base(interval)
        {
            base.Elapsed += new ElapsedEventHandler(TickableTimer_Elapsed);
        }
        public void Tick()
        {
            new System.Threading.Thread(delegate(object sender)
            {
                Dictionary<string, object> args = new Dictionary<string, object>
                {
                    {"signalTime", DateTime.Now},
                };
                TickableTimer_Elapsed(this, Mock.Create<ElapsedEventArgs>(args));
            }).Start();
            this.m_autoResetEvent.WaitOne();
        }
        void TickableTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            m_autoResetEvent.Set();
            if (this.Elapsed != null)
                this.Elapsed(sender, e);
        }
    }
