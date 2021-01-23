    interface IFactory<T>
    {
        T CreateInstance();
    }
    class Singleton
    {
        class Factory : IFactory<Singleton>
        {
            public Singleton CreateInstance()
            {
                // return a clone of _MainInstance
                return new Singleton(_MainInstance);
            }
        }
        // *** Begin "First one wins" approach
        static IFactory<Singleton> _FactoryFirstOneWins;
        public static IFactory<Singleton> GetFactoryFirstOneWins()
        {
            if (_FactoryFirstOneWins != null)
                throw new InvalidOperationException("A factory has already been created.");
            return _FactoryFirstOneWins = new Factory();
        }
        // *** End "First one wins" approach
        // *** Begin "Indirect assignment" approach
        public static void AssignFactories()
        {
            MainClass.SingletonFactory = new Factory();
        }
        // *** End "Indirect assignment" approach
        private static readonly Singleton _MainInstance = new Singleton();
        public static Singleton MainInstance
        {
            get { return _MainInstance; }
        }
        private Singleton()
        {
            // perform initialization logic
            this.SomeValue = 5; // pick some arbitrary number
        }
        private Singleton(Singleton instance)
        {
            // perform cloning logic here to make "this" a clone of "instance"
            this.SomeValue = instance.SomeValue;
        }
        public int SomeValue { get; set; }
        public void DoSomething()
        {
            Console.WriteLine("Singleton.DoSomething: " + this.SomeValue);
            // ...
        }
    }
    class MainClass
    {
        private static IFactory<Singleton> _SingletonFactory;
        public static IFactory<Singleton> SingletonFactory
        {
            get { return _SingletonFactory; }
            set { _SingletonFactory = value; }
        }
        public Singleton Singleton { get; private set; }
        public MainClass()
        {
            this.Singleton = SingletonFactory.CreateInstance();
        }
        public void DoWork()
        {
            Console.WriteLine("MainClass.DoWork");
            this.Singleton.DoSomething();
            // ...
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // you could either use the "First one wins" approach
            MainClass.SingletonFactory = Singleton.GetFactoryFirstOneWins();
            // or use the "Indirect assignment" approach
            Singleton.AssignFactories();
            // create two separate MainClass instances
            MainClass mc1 = new MainClass();
            MainClass mc2 = new MainClass();
            // show that each one utilizes a Singleton cloned from Singleton.MainInstance
            mc1.DoWork();
            mc2.DoWork();
            // updating mc1.Singleton.SomeValue does not affect any other instances of MainClass
            mc1.Singleton.SomeValue = 7;
            mc1.DoWork();
            mc2.DoWork();
            // updating Singleton.MainInstance.SomeValue affects any new instances of MainClass, but not existing instances
            Singleton.MainInstance.SomeValue = 10;
            MainClass mc3 = new MainClass();
            mc1.DoWork();
            mc2.DoWork();
            mc3.DoWork();
        }
    }
