    class Program
    {
        delegate void B();
        static Test t = new Test();
        static B b = t.A;
        static void Main(string[] args)
        {
            b();
        }
    }
    class Test
    {
        public void A()
        {
        }
    }
