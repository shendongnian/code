    private void BeginUpdate()
    {
      this.SuspendLayout();
      // Do paint events
      EndUpdate();
    }
    
    private void EndUpdate()
    {
       this.ResumeLayout();
       // Raise an event if needed.
    }
