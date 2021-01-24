     // "Func Factory"
     public class A
     {
       private Func<B> _bFactory;
       private B b
       {
         if (_b == null)
         {
          _b = _bFactory();
         }
         return _b;
       }
       public A(Func<B> bFactory)
       {
         _bFactory = bFactory;
       }
       public void SomeMethod()
       {
         b.DoSomething();
       }
     }
