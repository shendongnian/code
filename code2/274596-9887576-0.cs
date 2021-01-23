    public class A
    {
       internal protected A() {}
    }
    
    public class AFactory
    {
       public A CreateA()
       {
          return new InternalA();
       }
    
       private class InternalA : A
       {
          public InternalA(): base() {}
       }
    }
