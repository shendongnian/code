    Assembly 1:
    internal class Exclusive
    {
      public Exclusive() {}
      public void DoSomething() {}
    }
    public class Factory
    {
      public Exclusive GetExclusive() { return new Exclusive(); }
    }
    Assembly 2:
   
    Factory MyFactory = new Factory();
    Exclusive MyExclusive = MyFactory.GetExclusive(); // Error: class Exclusive not found
