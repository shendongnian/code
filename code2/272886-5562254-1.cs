    public class MegaAPI
    {
        private object sync = new object();
    
        public int SomeStupidBlockingFunction(int c)
        {
            lock (this.sync)
            {
                Thread.Sleep(800);
                return ++c;                
            }
        }
    }
