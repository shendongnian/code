    public void DoSomeUpdate(string text)
    {
        if(this.IsDisposed || (!this.IsHandleCreated))
        {
            // error condition; run away!
            return;
        }
        if(this.InvokeRequired)
        {
            // BeginInvoke or Invoke here, based on the semantics you need
            return;
        }
        this.UpdateSomeLabel(text);
    }
