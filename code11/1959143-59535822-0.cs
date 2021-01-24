    public abstract class Item<T> {
      public abstract T SerialNumber { get; }
    }
    public  class Toy : Item<int> {
      public override int SerialNumber => 5;
    }
