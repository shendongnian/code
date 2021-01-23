    class MyTask
    {
        bool bShouldDoWork;
        
        public event EventHandler Aborted;
    
        public void DoWork()
        {    
             bShouldDoWork = true;          
    
             while(bShouldDoWork)
             {
                  //Do work.
                  //But ensure that the loop condition is checked often enough to
                  //allow a quick and graceful termination. 
             }
    
             if(Aborted != null)
             {
                  //Fire event
                  Aborted(this, EventArgs.Empty);
             }
        }
        
        //Call this method from another thread, for example
        //when a button is pressed in your UI etc.
        public void Abort()
        {
             bShouldDoWork = false;
        }
    }
