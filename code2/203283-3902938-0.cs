    public interace ITimer 
    {
         long GetCurrentTicks()
    }
    public class Timer : ITimer
    {
        public long GetCurrentTicks() 
        {
            return DateTime.Now.Ticks;
        }
    }
    public class TestTimer : ITimer
    {
        private bool firstCall = true;
        private long last;
        private int counter = 1000000000;
        public long GetCurrentTicks()
        {
            if (firstCall)
                last = counter * 10000;
            else
                last += 3500;  //ticks; not sure what a good value is here
            
            //set up for next call;
            firstCall = !firstCall;
            counter++;
            return last;
        }
    }
