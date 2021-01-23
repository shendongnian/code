    public class MyAttr : Attribute { 
      // Any types used must implement IValueRange.
      public Type IValueRangeImplementation { get; set; } 
    }
    public interface IValueRange {
      int Start { get; }
      int End { get; }
    }
    public class Foo { 
      [MyAttr(IValueRangeImplementation = typeof(FooValueRange))]     
      public string Prop { get; set; }
      
      class FooValueRange : IValueRange {
        public int Start { get { return 10; } }
        public int End { get { return 20; } }
      }
    }
