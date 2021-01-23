       class Program
    {
        static void Main(string[] args)
        {
            List<A> list = new List<A>
            {
                new B(),
                new B(),
                new B(),
                new B()
            };
            foreach (A a in list)
            {
                a.Foo();
            }
            foreach (B b in list)
            {
                b.Foo();
            }
            Console.ReadLine();
        }
    }
    public class A
    {
        public void Foo()
        {
            Console.WriteLine("Base");
        }
    }
    public class B : A
    {
        public new void Foo()
        {
            Console.WriteLine("Derived");
        }
    }
