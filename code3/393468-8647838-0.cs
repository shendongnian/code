    public class BaseClass
    {
       public virtual void SomeMethod()
       {
           Console.WriteLine ("BaseClass");
       }
    }
    
    public class DerivedA : BaseClass
    {
        public override SomeMethod()
        {
            Console.WriteLine("DerivedA");
        }
    }
    
    public class DerivedB : BaseClass
    {
        public override SomeMethod()
        {
           Console.WriteLine ("DerivedB");
        }
    }
    
    BaseClass bc = someVariable;
    
    bc.SomeMethod();
