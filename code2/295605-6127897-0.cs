    class Parent
    {
        public virtual void Validate() { Console.WriteLine("P"); }
    }
    class ChildA : Parent
    {
        public override void Validate() { Console.WriteLine("A"); }
    }
    class ChildB : Parent
    {
        public override void Validate() { Console.WriteLine("B"); }
    }
    void Run()
    {
        var list = new List<Parent> { new ChildA(), new ChildB() };
        list[0].Validate();
        list[1].Validate();
        list[2].Validate();
    }
