    public void WorkerFinished(object sender, RunWorkerCompletedEventArgs e)
    {
        //You should always check e.Cancelled and e.Error before checking e.Result!
        // ... even though I'm skipping that here
        Worker w = e.Result as Worker;
        if( w != null)
        {
            if (_onManagerEvent != null)
                _onManagerEvent(new ManagerEvent 
                        { 
                          EventDate = DateTime.Now, 
                          Message = String.Format("Worker {0} successfully ended."
                                                  , w.ToString()) 
                        });
        }
    }
