    public static class Pi
    {
        private static float pi = 0;
        
        public static float GetValue()
        {
            if (pi == 0)
                pi = 3.141592653F;   // Expensive pi calculation goes here.
            return pi;
        }
    }
