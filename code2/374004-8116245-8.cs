    public class Foo {
      private IA a;
      private IB b;
      public void SetValue<T>(T value) where T : IA, IB {
        a = value;
        b = value;
      }
    }
