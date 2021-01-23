    class Program
    {
        static void Main(string[] args)
        {
            Customer1 c1 = new Customer1();
            DoSomething(c1);
            Customer2 c2 = new Customer2();
            DoSomething(c2);
        }
        static void DoSomething<T>(T customer) where T : Customer
        {
            //... code here ...
            customer.Initialize();
            //... code here ...
        }
    }
    abstract class Customer
    {
        public abstract void Initialize();
    }
    class Customer1 : Customer
    {
        public int Reference;
        public string Name;
        public override void Initialize()
        {
            this.Reference = 1234;
            this.Name = "John";
        }
    }
    class Customer2 : Customer
    {
        public string Name;
        public string Town;
        public override void Initialize()
        {
            this.Name = "Mary";
            this.Town = "Tokyo";
        }
    }
