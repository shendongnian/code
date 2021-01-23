    interface ICustomer
    {
        void Initialize();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer1 c1 = new Customer1();
            DoSomething(c1);
            Customer2 c2 = new Customer2();
            DoSomething(c2);
        }
        static void DoSomething<T>(T customer) where T : ICustomer
        {
            customer.Initialize();
         }
    }
    class Customer1 : ICustomer
    {
        public void Initialize()
        {
            Reference = 1234;
            Name = "John";
        }
        public int Reference;
        public string Name;
    }
    class Customer2 : ICustomer
    {
        public void Initialize()
        {
            Name = "Mary";
            Town = "Tokyo";
        }
        public string Name;
        public string Town;
    }
