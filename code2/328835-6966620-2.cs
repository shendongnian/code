    new Timer(TimerTick,null,TimeSpan.Zero,TimeSpan.FromMinutes(2));
    
    private void TimerTick(object obj)
    {
         new Thread(() => {}).Start();
    }
