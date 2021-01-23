    public class Timer1
     {
     
         public static void Main()
         {
             System.Timers.Timer aTimer = new System.Timers.Timer();
             
             // Method which will be called once the timer has elapsed
             aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
             
             // Set the Interval to 3 seconds.
             aTimer.Interval=3000;
             
             // Start the timer counting down
             aTimer.Enabled=true;
     
             // This will get called immediately (before the timer has counted down
             Console.WriteLine("Press \'q\' to quit the sample.");
             while(Console.Read()!='q');
         }
     
         // Specify what you want to happen when the Elapsed event is raised.
         private static void OnTimedEvent(object source, ElapsedEventArgs e)
         {
             // Timer has finished!
             Console.WriteLine("3 seconds has elapsed");
             // Add whatever logic you want here
             Environment.Exit(1);
         }
     }
