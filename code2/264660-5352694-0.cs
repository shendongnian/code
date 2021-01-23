    class A
    {
        public event EventHandler Event;
        public void Fire()
        {
            if (this.Event != null)
            {
                this.Event(this, new EventArgs());
            }
        }
        public EventHandler GetInvocationList()
        {
            return this.Event;
        }
    }
