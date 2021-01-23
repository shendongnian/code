    public class Base
    {
        public virtual void Foo()
        {
            Console.WriteLine("Hello from Base");
        }
    }
    public class Derived : Base
    {
        public bool WriteText2 { get; set; }
        public Derived()
        {
            WriteText2 = true;
        }
        public override void Foo()
        {
            base.Foo();
            Console.WriteLine("Text 1");
            if (WriteText2)
                Console.WriteLine("Text 2");
            Console.WriteLine("Text 3");
        }
    }
    public class Special : Derived
    {
        public override void Foo()
        {
            WriteText2 = false;
            base.Foo();
        }
    }
