    class A
    {
        public event EventHandler UpdateFinished;
    
        public void Update()
        {
              ... do work
            var handler = UpdateFinished;
            if (handler != null)
            {
                 handler(this, EventArgs.Empty);
            }
        }
    }
    class B
    {
        public void Draw()
        {
            a_inst.UpdateFinished += HandleUpdateFinished;
            ... start your thread
        }
        private void HandleUpdateFinished(object sender, EventArgs e)
        {
             ... do whatever
        }
    }
