    class MyBaseImplementation
    {
        public virtual void MyMethod()
        {
            Console.WriteLine("Base");
        }
    }
    class MyDerivedImplementation : MyBaseImplementation
    {
        public override void MyMethod()
        {
            Console.WriteLine("Derived");
        }
    }
    static void DoSomething(MyBaseImplementation instance)
    {
        instance.MyMethod();
    }
    static void Main(string[] args)
    {
        MyBaseImplementation inst = new MyDerivedImplementation();
        DoSomething(inst);
    }
