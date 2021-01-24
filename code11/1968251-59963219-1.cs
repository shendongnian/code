    public class Temporizador
    {
        private static Timer timer;
    
        public  void defTime(int timeSeconds)
        {            
            // Firstly, create a timer object for X seconds interval 
            timer = new System.Timers.Timer();
            timer.Interval = timeSeconds;
    
            // Set elapsed event for the timer. This occurs when the interval elapses −
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = false;
            // Now start the timer.
            timer.Enabled = true;   
        }
    
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Raised: {0:HH:mm:ss}", e.SignalTime);     
        }
    }
    
