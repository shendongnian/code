    public class ViewModel : INotifyPropertyChanged  
    {
      public DateTime ElapsedTime {get; private set;}
      public bool IsRunning {get; private set;}
      private BackgroundWorker worker = new BackgroundWorker();
      private DateTime startTime;
      private DispatcherTimer t = new DispatcherTimer();
      public ViewModel()
      {
        t.Interval = 500; 
        t.Tick += (ox,ex) => UpdateTime();
        worker.DoWork += YourMethodHere;
        worker.RunWorkerCompleted += (ox,ex)=> {
          IsRunning = false;
          if (PropertyChanged != null)
           PropertyChanged(this, new PropertyChangedEventArgs("IsRunning"));
        };
      }
      public void UpdateTime()
      {
         ElapsedTime=startTime.Subtract(DateTime.Now);
         if (PropertyChanged != null)
           PropertyChanged(this, new PropertyChangedEventArgs("ElapsedTime"));
      }
      public void Start()
      {
        startTime=DateTime.Now;
        worker.RunWorkerAsync();
        IsRunning = true;
        if (PropertyChanged != null)
         PropertyChanged(this, new PropertyChangedEventArgs("IsRunning"));
      }
