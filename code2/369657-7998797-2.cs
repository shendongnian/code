    public struct Rational
    {
        // Other members
        public Rational Add(Rational other)
        {
            ...
        }
        public static Rational operator +(Rational left, Rational right)
        {
            return left.Add(right);
        }
    }
