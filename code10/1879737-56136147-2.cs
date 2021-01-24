    public partial class ObeyOrder : IObeyOrder
    {
        public void Method1()
        {
            CheckOrder();
            Console.WriteLine("Method1");
        }
        public void Method2()
        {
            CheckOrder();
            Console.WriteLine("Method2");
        }
        public void Method3()
        {
            CheckOrder();
            Console.WriteLine("Method3");
        }
        public void Method4()
        {
            CheckOrder();
            Console.WriteLine("Method4");
        }
        public void Method5() // non-interface
        {
            CheckOrder();
            Console.WriteLine("Method5");
        }
    }
