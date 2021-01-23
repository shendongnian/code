    delegate void MyAction();
    // members
    Timer tmr1, tmr2, tmr3;
    int tmr1_interval = 4.2, 
        tmr2_interval = 3.5;
        tmr3_interval = 1;
    // ctor
    public MyClass()
    {
      ..
      ConfigTimer(tmr1, tmr1_interval, this.Tmr_Tick();
      ConfigTimer(tmr2, tmr2_interval, (sndr,ev) => { SecondTimer_Tick(sndr,ev); 
      ConfigTimer(tmr3, tmr3_interval, new MyAction((sndr,ev) => { Tmr_Tick((sndr,ev); }));
      ..
    }
    
    private void ConfigTimer(Timer _tmr, int _interval, MyAction mymethod)
    {
      _tmr = new Timer() { Interval =  _interval * 1000 };
      // lambda to 'ElapsedEventHandler' Tick
      _tmr.Elpased += (sndr, ev) => { mymethod(sndr, ev); };
      _tmr.Start();
    }
    private void Tmr_Tick(object sender, ElapsedEventArgs e)
    {
      // cast the sender timer
      ((Timer)sender).Stop();
      /* do your stuff here */
      ((Timer)sender).Start();
    }
    // Another tick method
    private void SecondTimer_Tick(object sender, ElapsedEventArgs e) {..}
