    public struct Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
    
        public Fraction(int numerator, int denominator)
            : this()
        {
            Numerator = numerator;
            Denominator = denominator;
        }
    
        public Fraction Simplify()
        {
            int gcd = GCD();
            return new Fraction(Numerator / gcd, Denominator / gcd);
        }
    
        public Fraction InTermsOf(Fraction other)
        {
            return Denominator == other.Denominator ? this :
                new Fraction(Numerator * other.Denominator, Denominator * other.Denominator);
        }
    
        public int GCD()
        {
            int a = Numerator;
            int b = Denominator;
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
    
        public Fraction Reciprocal()
        {
            return new Fraction(Denominator, Numerator);
        }
    
    
        public static Fraction operator +(Fraction left, Fraction right)
        {
            var left2 = left.InTermsOf(right);
            var right2 = right.InTermsOf(left);
    
            return new Fraction(left2.Numerator + right2.Numerator, left2.Denominator);
        }
    
        public static Fraction operator -(Fraction left, Fraction right)
        {
            var left2 = left.InTermsOf(right);
            var right2 = right.InTermsOf(left);
    
            return new Fraction(left2.Numerator - right2.Numerator, left2.Denominator);
        }
    
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        }
    
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }
    
        public static implicit operator Fraction(string value)
        {
            var tokens = value.Split('/');
            int num;
            int den;
            if (tokens.Length == 1 && int.TryParse(tokens[0], out num))
            {
                return new Fraction(num, 1);
            }
            else if (tokens.Length == 2 && int.TryParse(tokens[0], out num) && int.TryParse(tokens[1], out den))
            {
                return new Fraction(num, den);
            }
            throw new Exception("Invalid fraction format");
        }
    
        public override string ToString()
        {
            return string.Format("{0}/{1}", Numerator, Denominator);
        }
    }
