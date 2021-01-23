    public event EventHandler Get_DataCompleted;
    private int pendingCalls;
    private void OnCompleted()
    {
      pendingCalls -= 1;
      if (pendingCalls == 0 && Get_DataCompleted != null)
        Get_DataCompleted(this, EventArgs.Empty);
    }
    void service_StochSlowCompleted(object sender, StochSlowCompletedEventArgs e)
    {
      int count = e.Result.Count / 2;
      for (int i = 0; i < count; i++)
      {
        Stoch.Add(e.Result[i]);
      }
      OnCompleted();
    }
    void service_MovingAvgCompleted(object sender, MovingAvgCompletedEventArgs e)
    {
      MA = e.Result;
      OnCompleted();
    }
    void service_MomentumCompleted(object sender, MomentumCompletedEventArgs e)
    {
      PMO = e.Result;
      OnCompleted();
    }
    void service_RSICompleted(object sender, RSICompletedEventArgs e)
    {
      RSI = e.Result;
      OnCompleted();
    }
    void service_OBVCompleted(object sender, OBVCompletedEventArgs e)
    {
      OBV = e.Result;
      OnCompleted();
    }
    public void Get_Data(ObservableCollection<double> high, ObservableCollection<double> low, ObservableCollection<double> open, ObservableCollection<double> close, ObservableCollection<double> volume, ObservableCollection<DateTime> date)
    {
      if (pendingCalls > 0)
        throw new InvalidOperationException();
      pendingCalls = 5;
      service.OBVAsync(0, close.Count - 1, close, volume);
      service.RSIAsync(0, close.Count - 1, close, 9);
      service.StochSlowAsync(0, close.Count - 1, high, low, close, 14, 3, 14);
      service.MomentumAsync(0, close.Count - 1, close, 10);
      service.MovingAvgAsync(0, close.Count - 1, close, 10);
      Close = close;
      Date = date;
    }
    public void Predict()
    {
      //some code uses the results returned from the serivce 
    } 
