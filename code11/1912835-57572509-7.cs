    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo
            {
                a = new A
                {
                    x = "test data",
                },
                b = new B
                {
                    y = "test data",
                },
                c = new C[]
               {
                    new C
                    {
                        z = "hello",
                        d = new D
                        {
                            p = "This is D's property"
                        }
                    },
                    new C
                    {
                        z = "Hi",
                        d = new D
                        {
                            p = "Another D's property"
                        }
                    },
               }
            };
            Console.WriteLine(demo.a.x);
            Console.WriteLine(demo.b.y);
            foreach (var c in demo.c)
            {
                Console.WriteLine(c.z);
                Console.WriteLine(c.d.p);
            }
            Console.ReadKey();
        }
    }
    public class Demo
    {
        public A a { get; set; }
        public B b { get; set; }
        public C[] c { get; set; }
        public D d { get; set; }
    }
    public class A
    {
        public string x { get; set; }
    }
    public class B
    {
        public string y { get; set; }
    }
    public class C
    {
        public string z { get; set; }
        public D d { get; set; }
    }
    public class D
    {
        public string p { get; set; }
    }
     
