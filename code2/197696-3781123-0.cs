    Assembly 1:
    public class Exclusive
    {
      internal Exclusive() {}
      public void DoSomething() {}
    }
    public class Factory
    {
      public Exclusive GetExclusive() { return new Exclusive(); }
    }
    Assembly 2:
   
    Factory MyFactory = new Factory();
    Exclusive MyExclusive = MyFactory.GetExclusive(); // Object is created in Assembly 1
    MyExclusive.DoSomething();
    Exclusive MyExclusive = new Exclusive(); // Error: constructor is internal
