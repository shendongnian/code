    public class TimeoutChecker
    {
        private static Dictionary<Thread, DateTime> hashTimeouts
            = new Dictionary<Thread, DateTime>();
        static TimeoutChecker()
        {
            new Thread(CheckThread).Start();
        }
        protected static void CheckThread()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    foreach (DateTime t in hashTimeouts.Values)
                    {
                        if (DateTime.Now.AddMilliseconds(10 * 1000) < t)
                        {
                            //Perform recovery logic.
                        }
                    }
                }
                catch (Exception) { }
            }
        }
        public static void BeforeCall()
        {
            hashTimeouts.Add(Thread.CurrentThread, DateTime.Now);
        }
        public static void AfterCall() //be sure to execute in a finally...
        {
            hashTimeouts.Remove(Thread.CurrentThread);
        }
    }
