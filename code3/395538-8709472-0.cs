    class Example {
    
      public string Value { get; set; }
      public Example(string value) {
        Value = value;
      }
      public override string ToString() {
        return Value;
      }
    }
