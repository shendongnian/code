    var timer1= new MyTimerClass(this.OnTimerError);
     timer1.Execute("Device A");
    _timers.Add(timer1);
    
     var timer2= new MyTimerClass(this.OnTimerError);
     timer2.Execute("Device B");
    _timers.Add(timer2);
    public void OnTimerError(MyTimerClass timer, Exception error)
    {
     //Log the exception
      _timers.Remove(timer);
    }
