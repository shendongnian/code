    public partial class App : Application
    {
      protected override void OnStartup(System.Windows.StartupEventArgs e)
      { 
        BackgroundWorker _backgroundWorker;
        if (_backgroundWorker != null)
        {
         _backgroundWorker.CancelAsync();
        }
        _backgroundWorker = CreateBackgroundWorker();
        _backgroundWorker.RunWorkerAsync(); 
      }
    }
    
    private BackgroundWorker CreateBackgroundWorker()
    {
        var bw = new BackgroundWorker();
        bw.WorkerReportsProgress = true;
        bw.WorkerSupportsCancellation = true;
        bw.DoWork += _backgroundWorker_DoWork;
        bw.ProgressChanged += _backgroundWorker_ProgressChanged;
        bw.RunWorkerCompleted +=  _backgroundWorker_RunWorkerCompleted;
        return bw;
    }
    
    private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
    }
    
    private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      
    }
    
    private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
                         
    }
