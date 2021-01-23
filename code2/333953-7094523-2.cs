      private void solveButton_Click(object sender, RoutedEventArgs e)
        {
           BackgroundWorker bg = new BackgroundWorker();
           bg.DoWork += new DoWorkEventHandler(DoWork);
           bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
           bg.RunWorkerAsync(); 
    
           progressBar1.Visibility = Visibility.Visible;
           progressBar1.IsIndeterminate = true;         
        }
        
    void DoWork(Object sender, DoWorkEventArgs args)
    {
         mySolver.Solve(initialValue)
    }
    
    void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
    {
    
        //  this method will be called once background worker has completed it's task
          progressBar1.Visilibity=Visilibity.collapsed;
          progressBar1.IsIndeterminate = false
    }
