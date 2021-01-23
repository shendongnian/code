    public static class Pi
    {
        private static float pi;
        
        public static float GetValue()
        {
            if (pi == null)
                pi = 3.141592653F;
            return pi;
        }
    }
