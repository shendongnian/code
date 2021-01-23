    BackgroundWorker worker = new BackgroundWorker(); 
    void WriteButton_Clicked(object sender, EventArgs args)
    {
       //start writing to the file asynchronously, something like
       //worker.DoWork += (s,e) => { /*writing to file*/ };
    }
    
    void ExitButton_Clicked(object sender, EventArgs args)
    {
       if (worker.IsBusy)
       {
          //show a dialog window
          if (CANCEL)
          {
             worker.CancelAsync();
             //but rolling the changes back is a nightmare!!
          }
          else
          {
             //exit the applcation when worker.RunWorkerCompleted
          }
       }
    }
