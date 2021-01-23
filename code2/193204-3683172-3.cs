    public static class TermHelper
    {
        public static Term Times(this int number, Term multiplier)
        {
            return ((Term)number).Times(multiplier);
        }
    
        public static Term DividedBy(this int number, Term divisor)
        {
            return ((Term)number).DividedBy(divisor);
        }
    }
