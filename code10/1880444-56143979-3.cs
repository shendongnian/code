    public Book {
      ...
      const Decimal PriceThreshold = 30.0m;
      const Decimal ReducePerCent = 10.0m; 
    
      private Decimal m_NetPrice;
    
      // Net price
      // Decimal (not Single, Double) usually is a better choice for finance
      public Decimal NetPrice {
        get {
          return m_NetPrice;
        }
        set {
          if (value < 0) 
            throw new ArgumentOutOfRangeException(nameof(value));
    
          m_NetPrice = value;
        }
      }  
    
      // Price with possible reduction
      public Decimal Price {
        get {
          return NetPrice > PriceThreshold 
            ? NetPrice - NetPrice / 100.0m * ReducePerCent
            : NetPrice;
        } 
      } 
    }
