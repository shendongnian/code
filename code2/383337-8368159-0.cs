    class A
    {
        public virtual void Frob()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public virtual void Frob()
        {
            Console.WriteLine("B");
        }
    }
    class C : B
    {
        public override void Frob()
        {
            Console.WriteLine("C");
        }
    }
