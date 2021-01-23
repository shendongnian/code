    private Bar(int a, int b) : base(a, b) {
      ...
    }
    
    public static Bar Create(int a, bool plusOrMinus) {
      if (plusOrMinus) {
        return new Bar(a, 5);
      } else {
        return new Bar(a, -5);
      }
    }
