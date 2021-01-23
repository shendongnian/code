    public interface IValueRange {
      int Start { get; }
      int End { get; }
    }
    public class MyAttr : Attribute { 
      // The used type must implement IValueRange
      public Type ValueRangeType { get; set; } 
    }
    // ....
    public class Foo { 
      class FooValueRange : IValueRange {
        public int Start { get { return 10; } }
        public int End { get { return 20; } }
      }
      [MyAttr(ValueRangeType = typeof(FooValueRange))]
      public string Prop { get; set; }
    }
