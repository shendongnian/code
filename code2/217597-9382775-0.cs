    public System.Timers.Timer timer = new System.Timers.Timer(1000);
    public DateTime d;
    public void init()
    {
    timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
    
    d = new DateTime(2011, 11, 11, 23, 59, 50);
    d=d.AddHours(1);
    Console.Writeline(d);
    d=d.AddHours(-2);
    Console.Writeline(d);
    timer.Enabled = true;
    }
       void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
                MoveClockHands();
                d=d.AddSeconds(1);
                Console.WriteLine(d);
    
            }));
        }
        void MoveClockHands()  //12 hours clock
        (
           s=d.Second * 6;
           m=d.Minute * 6;
           h=0.5 * ((d.Hour % 12) * 60 + d.Minute)
        }
    
