    public partial class Service : ServiceBase{
    
        System.Timers.Timer timer;
    
    
     public Service()
        {
    
        timer = new System.Timers.Timer();
        //When autoreset is True there are reentrancy problme 
        timer.AutoReset = false;
    
    
        timer.Elapsed += new System.Timers.ElapsedEventHandler(DoStuff);
    }
    
     protected override void OnStart(string[] args)
     {
    
         timer.Interval = 1;
         timer.Start();
    
        }
    
     private void DoStuff(object sender, System.Timers.ElapsedEventArgs e)
     {
    
        Collection stuff = GetData();
        LastChecked = DateTime.Now;
    
        foreach (Object item in stuff)
        {
              item.Dosomthing(); //Do somthing should only be called once
         }     
    
    
        TimeSpan ts = DateTime.Now.Subtract(LastChecked);
        TimeSpan MaxWaitTime = TimeSpan.FromMinutes(5);
    
    
        if (MaxWaitTime.Subtract(ts).CompareTo(TimeSpan.Zero) > -1)
            timer.Interval = MaxWaitTime.Subtract(ts).Milliseconds;
        else
            timer.Interval = 1;
    
        timer.Start();
    
    
    
    
    
     }
