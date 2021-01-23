    public class Foo2 {
      private IA a;
      private IB b;
      public void SetValue<T>(T value) where T : IA, IB {
        a = value;
        b = value;
      }
    }
