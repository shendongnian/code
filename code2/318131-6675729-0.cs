    class A
    {
        public virtual void Print()
        {
            Console.Write(this.GetType().Name);
        }
    }
    class B : A
    {
        public override void Print()
        {
            base.Print();
            Console.Write(this.GetType().Name);
        }
    }
            var b = new B();
            b.Print();
