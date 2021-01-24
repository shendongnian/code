    public static class GlobalFunctions
    {
        static Random random = null;
        private static readonly object syncLock = new object();
    
        static GlobalFunctions()
        {
            lock (syncLock)
            {
                if (random == null)
                    random = new Random();
            }
        }   
    
        public static int RandomInt(int max)
        {
            lock (syncLock)
            {
                return random.Next(max);
            }
        } 
    }
