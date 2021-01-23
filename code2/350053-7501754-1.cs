    public class A
    {
        private double sum;
        private volatile bool running;
        private readonly object sync;
        public A()
        {
            sum = 0.0;
            running = true;
            sync = new object();
        }
        public void foo(S myStruct)
        {
            // You need to synchronize the whole block because you can get a race
            // condition (i.e. running can be set to false after you've checked
            // the flag and then you would be adding the sum when you're not 
            // supposed to be).
            lock(sync)
            {
                if(running)
                {
                    sum+=myStruct.Value;
                }
            }
        }
        
        public void stop()
        {
            // you don't need to synchronize here since the flag is volatile
            running = false;
        }
    }
