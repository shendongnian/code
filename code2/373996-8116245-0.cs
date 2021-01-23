    public class Foo {
      private Tuple<IA, IB> junction;
      public void SetValue<T>(T value) where T : IA, IB {
        junction = Tuple.Create<IA, IB>(value, value);
      }
    }
