    public static class Threads
    {
        public static void Sleep(int milisec)
        {
            DateTime now = DateTime.Now;
            DateTime endOfSleep = now.AddMilliseconds(milisec);
            while (DateTime.Now < endOfSleep)
            {
            }
        }
    }
