      public class FooItem {
        public FooItem(string id, double value1, string value2) {
          if (null == id)
            throw new ArgumentNullException(nameof(id)); 
          Id = id;
          Value1 = value1;
          Value2 = value2;
        } 
    
        public string Id { get; } 
    
        public double Value1 { get; }
        public string Value2 { get; }
      } 
