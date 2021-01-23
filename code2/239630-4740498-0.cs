    struct Negative0
    {
        double val;
        public static bool Equals(double d)
        {
            return new Negative0 { val = -0d }.Equals(new Negative0 { val = d });
        }
    }
Negative0.Equals(0); // false
Negative0.Equals(-0.0); // true
