    public class Timer1
     {
         private int timeRemaining;
     
         public static void Main()
         {
             timeRemaining = 120; // Give the player 120 seconds
             System.Timers.Timer aTimer = new System.Timers.Timer();
             
             // Method which will be called once the timer has elapsed
             aTimer.Elapsed + =new ElapsedEventHandler(OnTimedEvent);
             
             // Set the Interval to 3 seconds.
             aTimer.Interval = 3000;
             // Tell the timer to auto-repeat each 3 seconds
             aTimer.AutoReset = true;
             // Start the timer counting down
             aTimer.Enabled = true;
     
             // This will get called immediately (before the timer has counted down)
             Game.StartPlaying();
         }
     
         // Specify what you want to happen when the Elapsed event is raised.
         private static void OnTimedEvent(object source, ElapsedEventArgs e)
         {
             // Timer has finished!
             timeRemaining -= 3; // Take 3 seconds off the time remaining
             
             // Tell the player how much time they've got left
             UpdateGameWithTimeLeft(timeRemaining);
         }
     }
