     public class ThreadSleep : IThreadSleep
    {
        public void Sleep(int milliSec)
        {
            Thread.Sleep(milliSec);
        }
    }
