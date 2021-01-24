    class Program
    {
        static bool boxCollider = true;
        static Timer aTimer;
        static void Main(string[] args)
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                Console.WriteLine("The key was pressed at {0:HH:mm:ss.fff}", DateTime.Now);
                boxCollider = true;
                aTimer = new System.Timers.Timer(2000);
                aTimer.Elapsed += onTimerEnded;
                aTimer.Enabled = true;
            }
            Console.ReadLine();
        }
    
        private static void onTimerEnded(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                          e.SignalTime);
            Enable();
            aTimer.Enabled = false;
            aTimer.Dispose();
        }
    
        private static void Enable()
        {
            boxCollider = true;
        }
