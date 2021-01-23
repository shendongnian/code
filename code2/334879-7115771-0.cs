    public class A
    {
        public virtual void Foo()
        {
            Console.WriteLine("Called from A");
        }
    }
    public class B : A
    {
        public override void Foo()
        {
            Console.WriteLine("Called from B");
        }
    }
