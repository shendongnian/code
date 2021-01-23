    public class ABJunction {
      public IA A { get; private set; }
      public IB B { get; private set; }
      private ABJunction() { }
      public static ABJunction Create<T>(T value) where T: IA, IB {
        return new ABJunction {
          A = value,
          B = value
        };
      }
    }
    public class Foo {
      private ABJunction junction;
      public void SetValue<T>(T value) where T : IA, IB {
        junction = ABJunction.Create(value);
      }
    }
