    using System;
    using System.Threading;
    using System.ComponentModel;
     
    class Program
    {
      static BackgroundWorker _bw;
     
      static void Main()
      {
        _bw = new BackgroundWorker
        {
          WorkerReportsProgress = true,
          WorkerSupportsCancellation = true
        };
        _bw.DoWork += bw_DoWork;
        _bw.ProgressChanged += bw_ProgressChanged;
        _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
     
        _bw.RunWorkerAsync ("Hello to worker");
     
        Console.WriteLine ("Press Enter in the next 5 seconds to cancel");
        Console.ReadLine();
        if (_bw.IsBusy) _bw.CancelAsync();
        Console.ReadLine();
      }
     
      static void bw_DoWork (object sender, DoWorkEventArgs e)
      {
        for (int i = 0; i <= 100; i += 20)
        {
          if (_bw.CancellationPending) { e.Cancel = true; return; }
          _bw.ReportProgress (i);
          Thread.Sleep (1000);      // Just for the demo... don't go sleeping
        }                           // for real in pooled threads!
     
        e.Result = 123;    // This gets passed to RunWorkerCompleted
      }
     
      static void bw_RunWorkerCompleted (object sender,
                                         RunWorkerCompletedEventArgs e)
      {
        if (e.Cancelled)
          Console.WriteLine ("You canceled!");
        else if (e.Error != null)
          Console.WriteLine ("Worker exception: " + e.Error.ToString());
        else
          Console.WriteLine ("Complete: " + e.Result);      // from DoWork
      }
     
      static void bw_ProgressChanged (object sender,
                                      ProgressChangedEventArgs e)
      {
        Console.WriteLine ("Reached " + e.ProgressPercentage + "%");
      }
    }
