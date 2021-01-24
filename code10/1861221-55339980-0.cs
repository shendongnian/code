    class A
    {
        public virtual void Start()
        {
            Console.WriteLine("Starting A");
        }
    }
    class B
    {
        public override void Start()
        {
            base.Start();
            Console.WriteLine("Starting B");
        }
    }
