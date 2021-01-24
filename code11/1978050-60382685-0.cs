    public class A2
    {
      protected virtual void f() {Console.WriteLine("from A2");}
      protected virtual void g() {Console.WriteLine("From A2");}
      protected virtual void h1() {Console.WriteLine("from A2");}
    }
    
    //make a wrapper which will publish protected methods
    //ADVICE: always use interfaces, they MUCH more flexible as you will see in your own example, use abstract/static modifier with caution.
    public interface IA2
    {
        void f_public();
        void g_public();
        void h1_public();
    }
    public class PublicA2 : A2, IA2
    {  
       public void f_public(){f();}
       public void g_public(){g();}
       public void h1_public(){h1();}
    }
    //do the same for B2
