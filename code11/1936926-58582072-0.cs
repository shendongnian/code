    class Base<T> where T : BaseConf
    {
        public T Conf;
        public Base(T C)
        {
            Conf = C;
        }
    }
    class Derived : Base<DerivedConf>
    {
        public Derived(DerivedConf DC) : base(DC)
        { 
        }
        public void PrintName()
        {
            Console.WriteLine(Conf.Name);
        }
    }
    static void Main(string[] args)
    {
        var derived = new Derived(new DerivedConf("Foo"));
        derived.PrintName(); // Foo
    }
