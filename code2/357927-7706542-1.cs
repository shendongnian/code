    abstract class Super {
      protected abstract int Field { get; }
    }
    class Sub : Super {
      protected override int Field { get { return 5; } }
    }
