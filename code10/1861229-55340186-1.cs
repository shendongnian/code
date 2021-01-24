    class A
    {
        public virtual void Start() => Console.WriteLine("A.Start()");
    }
    
    class B : A
    {
        public override void Start()
        {
            Console.WriteLine("B.Start()");
            base.Start();
        }
    }
    
    // usage:
    A a = new B();
    a.Start();
    
    // Output:
    // B.Start()
    // A.Start();
