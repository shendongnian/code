        /// <summary>
        /// Lock for SomeEvent delegate access.
        /// </summary>
        private readonly object someEventLock = new object();
        /// <summary>
        /// Delegate variable backing the SomeEvent event.
        /// </summary>
        private SomeEventHandler someEvent;
        /// <summary>
        /// Defines an event handler.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void SomeEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Description for the event.
        /// </summary>
        public event SomeEventHandler SomeEvent
        {
            add
            {
                lock (this.someEventLock)
                {
                    this.someEvent += value;
                }
            }
            remove
            {
                lock (this.someEventLock)
                {
                    this.someEvent -= value;
                }
            }
        }
        /// <summary>
        /// Raises the OnSomeEvent event.
        /// </summary>
        public void RaiseEvent()
        {
            this.OnSomeEvent(EventArgs.Empty);
        }
        /// <summary>
        /// Raises the SomeEvent event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnSomeEvent(EventArgs e)
        {
            SomeEventHandler handler;
            lock (this.someEventLock)
            {
                handler = this.someEvent;
            }
            if (handler != null)
            {
                handler(this, e);
            }
        }
