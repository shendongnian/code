    public class Junction {
      public IA A { get; private set; }
      public IB B { get; private set; }
      private Junction() { }
      public static Junction Create<T>(T value) where T: IA, IB {
        return new Junction {
          A = value,
          B = value
        };
      }
    }
    public class Foo {
      private Junction junction;
      public void SetValue<T>(T value) where T : IA, IB {
        junction = Junction.Create(value);
      }
    }
