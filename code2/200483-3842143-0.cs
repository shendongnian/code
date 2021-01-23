    public class Parent
    {
        public virtual void SayHello() { Console.WriteLine("Hello World!"); }
    }
    public class Child : Parent
    {
        public override void SayHello() { Console.WriteLine("Goodbye World!"); }
    }
