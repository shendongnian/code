    void Main()
    {
        typeof(Derived1).GetMethods().Dump();
    }
    
    public class Base1
    {
        public virtual void f()
        {
            Debug.WriteLine("Base1.f");
        }
    }
    
    public class Derived1 : Base1
    {
        public virtual new void f()
        {
            Debug.WriteLine("Derived1.f");
        }
    }
    
    public class Derived2 : Derived1
    {
        public override void f()
        {
            Debug.WriteLine("Derived2.f");
            base.f();
        }
    }
