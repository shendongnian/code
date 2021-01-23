     public Rational(long num, long den)
     {
             // and here (GCD is underline) the 4. error
            long simple = GCD(num, den);
            this.Numerator = num;
            this.Denominator = den;
     }
