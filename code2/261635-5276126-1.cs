    public class WorkerThread
    {
        public void DoWork( object sender, DoWorkEventArgs e )
        {
           //get a handle on the worker that started this request
           BackgroundWorker workerSender = sender as BackgroundWorker;
    
           // loop through 10 times and report the progress back to the sending object
           for( int i = 0; i < 10; i++ )
           {
              // tell the worker that we want to report progress being made
              workerSender.ReportProgress( i );
              Thread.Sleep( 100 );
           }
    
           // cancel the thread and send back that we cancelled
           workerSender.CancelAsync();
           e.Cancel = true;
    
        }
    
        public void RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
           Console.WriteLine( "Worker Done!!" );          
        }
    
        public void ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
          // print out the percent changed
          Console.WriteLine( e.ProgressPercentage );
        }
    }
