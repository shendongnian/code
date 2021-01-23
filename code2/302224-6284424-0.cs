    Timer a= new Timer();
    a.Tick += TickMethod;
    a.interval = 2;
    BackgroundWorker b = new BackgroundWorker();
    b.DoWork += BackgroundMethod();
    b.WorkComplete += WorkDone();
    void Start()
    {
      a.Start();
      b.RunAsync();
    }
    void TickMethod()
    {
       if(progressBar.Value == progressBar.Max)
          progressBar.Value = 0;
       progresssBar.Step();
    }
    void BackgroundMethod(object s, Args e)
    {
       MakeConnection();
    }
    void WorkDone()
    {
      a.Stop();
      progressBar.Value = progressBar.Max();
    }
