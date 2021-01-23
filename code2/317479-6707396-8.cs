    public class TimeBoundWorker : IDoWorkForSomeTime
    {
        public void Work(int time)
        {
            Console.WriteLine("Working for {0} hours", time);
        }
    }
    public class AdvisedTimeBoundWorker : IDoWorkForSomeTime
    {
        /* *** Note The Attribute *** */
        [ChangeParameter]
        public void Work(int time)
        {
            Console.WriteLine("Working for {0} hours", time);
        }
    }
