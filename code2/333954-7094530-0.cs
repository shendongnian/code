    private void solveButton_Click(object sender, RoutedEventArgs e)
    {
        progressBar1.Visibility = Visibility.Visible;
        progressBar1.IsIndeterminate = true;
        
        solveButton.Enabled = false; //I reccomend this so the button can't be pressed twice.
 
        BackgroundWoker bw = new BackgroundWorker();
        bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        bw.DoWork += bw_DoWork;
        bw.ProgressChanged += bw_ProgressChanged;
        bw.RunWorkerAsync()
    
    }
    
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        mySolver.Solve(initialValue, e)
    }
    
    private void bw_RunWorkerCompleted(
        object sender, RunWorkerCompletedEventArgs e)
    {
        if(e.Error != null)
        {
             //Handle any exceptions that happened in the background worker.
        }
        progressBar1.Visilibity=Visilibity.collapsed;
        progressBar1.IsIndeterminate = false;
        solveButton.Enabled = true;
        ((IDisposable)sender).Dispose();
    }
    private void backgroundWorker1_ProgressChanged(object sender,
        ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    }
    //inside mySolver
    void Solve(somthing initialValue, DoWorkEventArgs e)
    {
        //Your solver work
        e.ReportProgress(progress); //a int from 0-100
        //more solver work
    }
