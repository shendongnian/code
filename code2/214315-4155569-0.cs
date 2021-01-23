    public class MyType : ICloneable
    {
      public MyType Clone() //called directly on MyType, returns MyType
      {
        return new MyType(/* class-dependant stuff goes here */);
      }
      object ICloneable.Clone() // called through ICloneable interface, returns object
      {
        return Clone();
      }
    }
