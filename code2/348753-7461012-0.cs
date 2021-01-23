    public class A
    {
        public A() { }
        public void Do() { Console.Write("A"); }
    }
    public class B : A
    {
        public B() { }
        public void Do() { Console.Write("B");  }
    }
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.Do(); //<-- outputs B
            (b as A).Do(); //<-- outputs A
          }
    }
