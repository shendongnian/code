    public class Base
    {
        public virtual void Foo()
        {
            Console.WriteLine ("Base");
        }
    }
    
    public class Derived : Base
    {
        public override void Foo()
        {
            Console.WriteLine ("Derived.");
        }
    }
