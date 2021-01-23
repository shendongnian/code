    public static class Randomizer
    {
        private static Random rnd;
        static Randomizer()
        {
            rnd = new Random();
            rndlock = new object();
        }
        
        private static object rndlock;
        public static int Next(int minValue, int maxValue)
        {
            lock(rndlock)
            {
                return rnd.Next(minValue, maxValue);
            }
        }
    }
