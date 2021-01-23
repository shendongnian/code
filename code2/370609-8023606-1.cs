    public struct Rational : IComparable<Rational>
    {
        private long _numerator;
        private long _denominator;
        public long Numerator { get{return _numerator;}; set{_numerator=value;} }
        public long Denominator{ get{return denominator;}; set{_denominator=value;} }
        public Rational(long num, long den)
        {
             // and here (GCD is underline) the 4. error
            long simple = GCD(num, den);
            this._numerator = num;
            this._denominator = den;
        }
