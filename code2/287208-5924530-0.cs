    //Add a class member
    private bool stopped;
    
    public void Stop() 
    {    
         if (!this._backgroundWorker.IsBusy)
         {
             this._timer.Enabled = false; 
             stopped = false;
         }
         else
         {
             stopped = true;
         }
    
    } 
    
    private void _backgroundWorker_RunWorkerCompleted(object sender,      RunWorkerCompletedEventArgs e) 
    {     
         DoSomethingElse(); 
         
        if (stopped)
        {
                 this._timer.Enabled = false; 
                 stopped = false;
        }
    } 
