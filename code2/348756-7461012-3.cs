    public class A
    {
        public A() { }
        public virtual void Do() { Console.Write("A"); }
    }
    public class B : A
    {
        public B() { }
        public  override void Do() { Console.Write("B");  }
    }
