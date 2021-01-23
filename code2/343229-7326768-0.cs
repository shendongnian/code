    public class Listener : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
       private BackgroundWorker _BW;
       public Listener()
       {
          _BW = new BackgroundWorker();
          _BW.WorkerReportsProgress = true;
          _BW.ProgressChanged += BW_ProgressChanged;
          _BW.DoWork += BW_DoWork;
          _BW.RunWorkerAsync();
          Input = string.Empty;
       }
       private void BW_DoWork(object sender, DoWorkEventArgs e)
       {
          while (true)
          {
              int ch = Console.In.Read();
              if (ch != -1)
              {
                  Input += Convert.ToChar(ch);
                  _BW.ReportProgress(0);
              }
          }
       }
       private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
       {
          PropertyChangedEventHandler h = PropertyChanged;
          if (h != null)
          {
              h(this, new PropertyChangedEventArgs("Input"));
          }
       }
       public string Input { get; private set; }
    }
