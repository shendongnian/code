    using System;
    
    public class MixedNumber {
        public MixedNumber(int wholePart, int num, int denom)
        {  
            WholePart = wholePart;
            Numerator = num;
            Denominator = denom;
            Normalize();
        }
       
        public int WholePart { get; private set; }
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }
       
        private int GCD(int a, int b)
        {  
            while(b != 0)
            {  
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
       
        private void Reduce(int x) {
            Numerator /= x;
            Denominator /= x;
        }
       
        private void Normalize() {
            // Add the whole part to the fraction so that we don't have to check its sign later
            Numerator += WholePart * Denominator;
    
            // Reduce the fraction to be in lowest terms
            Reduce(GCD(Numerator, Denominator));
    
            // Make it so that the denominator is always positive
            Reduce(Math.Sign(Denominator));
    
            // Turn num/denom into a proper fraction and add to wholePart appropriately
            WholePart = Numerator / Denominator;
            Numerator %= Denominator;
        }
       
        override public String ToString() {
            return String.Format("{0} {1}/{2}", WholePart, Numerator, Denominator);
        }
    }
