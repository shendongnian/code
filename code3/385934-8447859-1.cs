    abstract class Base
    {
      public int x { get; }
    }
    class Derived : Base
    {
      public new int x
      {
        get { //Actual Implementaion }
      }
    }
