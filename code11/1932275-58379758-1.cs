     // "Lazy Factory"
     public class A
     {
       private Lazy<B> _b;
       public A(Lazy<B> b)
       {
         _b = b;
       }
       public void SomeMethod()
       {
         b.Value.DoSomething();
       }
     }
