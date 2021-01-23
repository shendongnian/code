    struct Data
    {
      public decimal valueOne { get; set; }
      public decimal valueTwo { get; set; }
    }
    Dictionary<DateTime, Data> map = new Dictionary<DateTime, Data>();
    void addToMap(DateTime dt, decimal one, decimal two)
    {
      map[dt] = new Data() { valueOne = one, valueTwo = two };
    }
