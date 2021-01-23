    class Updater()
    {
            
      public ProgressBar pb;
            
      delegate void UpdateProgressBar();
            
      public StepProgressBar()
      {
         if(pb.InvokeRequired)
         {
              BeginInvoke(new UpdateProgressBar(this.StepProgressBar);
         }
         else
         {
              pb.Step();
          }
       }
    
    }
