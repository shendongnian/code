    struct ExpNumber 
    {
      public double Exponent { get; }
      public ExpNumber(double e) => Exponent = e;
      public static ExpNumber operator *(ExpNumber x1, ExpNumber x2) => 
        new ExpNumber(x1.Exponent + x2.Exponent);
