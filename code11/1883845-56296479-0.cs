    class Program
    {
        private static FixedDurationTimer aTimer;
        static void Main(string[] args)
        {
            // Create a timer and set a two second interval.
            aTimer = new FixedDurationTimer();
            aTimer.Interval = 2000;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            // Start the timer
            aTimer.StartWithDuration(TimeSpan.FromSeconds(15));
            Console.WriteLine("Press the Enter key to exit the program at any time... ");
            Console.ReadLine();
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            FixedDurationTimer timer = source as FixedDurationTimer;
            if (timer.Enabled)
            {
                Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            }
        }
        public class FixedDurationTimer : System.Timers.Timer
        {
            public TimeSpan Duration { get; set; }
            private Stopwatch _stopwatch;
            public void StartWithDuration(TimeSpan duration)
            {
                Duration = duration;
                _stopwatch = new Stopwatch();
                Start();
                _stopwatch.Start();
            }
            public FixedDurationTimer()
            {
                Elapsed += StopWhenDurationIsReached;
            }
            private void StopWhenDurationIsReached(object sender, ElapsedEventArgs e)
            {
                if (_stopwatch != null && Duration != null)
                {
                    if (_stopwatch.Elapsed > Duration)
                    {
                        Console.WriteLine("Duration has been met, stopping");
                        Stop();
                    }
                }
            }
        }
    }
