    private DateTime lastChange = DateTime.Now;
    private bool textChanged = false;
    object lockObject = new object();
    
    private void textChanged(object sender, EventArg e)
    {
       lock(lockObject)
       {
          lastChange = DateTime.Now;
          textChanged = true;
       }
    }
    private void timer1_Tick(object sender, EventArgs 
    {
        lock(lockObject)
        {
           if (textChanged && lastChange > DateTime.Now.AddSeconds(-2)) // wait 2 second for changes
           {
              UpdateList();
              textChanged = false;
              lastChange = DateTime.Now;
           }
        }
    }
