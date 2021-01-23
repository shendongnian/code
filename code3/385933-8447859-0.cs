    abstract class Base
    {
      public abstract int x { get; }
    }
    class Derived : Base
    {
      public override int x
      {
        get { //Actual Implementaion }
      }
    }
