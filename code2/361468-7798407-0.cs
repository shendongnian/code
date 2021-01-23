    public abstract class Base<T> where T : Base<T>
    {
        public virtual T Method()
        {
            return (T) this;
        }
    }
    
    public class Derived1 : Base<Derived1>
    {
        public override Derived1 Method()
        {
            return base.Method();
        }
    }
    
    public class Derived2: Base<Derived2> { }
    
    public class Program {
    public static int Main() {
        Derived1 d1 = new Derived1();
        Derived1 x = d1.Method();
        Derived2 d2 = new Derived2();
        Derived2 y = d2.Method();
        return 0;
    }
