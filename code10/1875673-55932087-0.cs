    public abstract class A
    {
    
       public int a { private set; get; }
    
       public A(int a)
       {
          this.a = a; // needed to be called
       }
    }
    
    public class B : A
    {
       // some user defined class forgets base constructor
       public B(int a) : base(a)
       {
       }
    }
