    new Timer(TimerTick,null,new TimeSpan(0,0,0),new TimeSpan(0,2,0)); //2 Minutes
    
    private void TimerTick(object obj)
    {
         new Thread(() => {}).Start();
    }
