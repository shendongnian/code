    class Program
    {
        static void Main(string[] args)
        {
            WriteOneEverySecond w = new WriteOneEverySecond();
            w.ScheduleInBackground();
            Console.ReadKey();
            w.StopTimer();
            Console.ReadKey();
        }
    }
    class WriteOneEverySecond
    {
        private Timer myTimer;
        public void StopTimer()
        {
            myTimer.Dispose();
            myTimer = null;
        }
        public void ScheduleInBackground()
        {
            myTimer = new Timer(RunJob, null, 1000, 1000);
        }
        public void RunJob(object state)
        {
            Console.WriteLine("Timer Fired at: " + DateTime.Now);
        }
    }
