    using System;
    using System.Timers;
    using System.Threading;
     
    class myApp
    {
        public static void Main()
    {
          System.Timers.Timer myTimer = new System.Timers.Timer();
          myTimer.Elapsed += new ElapsedEventHandler( myFanc );
          myTimer.Interval = 1000;
          myTimer.AutoReset = false;
          myTimer.Start();
      
          while ( Console.Read() != 'q' )
          {
              ;    // do nothing...
          }
        }
    public static void myFanc(object source, ElapsedEventArgs e)
    {
        Console.Write("\r{0}", DateTime.Now);
        Thread.Sleep(3000); //the sleep here is just to test the method, wait to be finished before another call the myFanc method is being performed
        System.Timers.Timer myTimer = new System.Timers.Timer();
        myTimer.Elapsed += new ElapsedEventHandler(myFanc);
        myTimer.Interval = 1000;
        myTimer.AutoReset = false;
        myTimer.Start();
    }
}
