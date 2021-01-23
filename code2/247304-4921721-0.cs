    class A
    {
        public virtual void Render()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public override void Render()
        {
            Console.WriteLine("B");
        }
    }
    class C : A
    {
        public override void Render()
        {
            Console.WriteLine("C");
        }
    }
    static void Main(string[] args)
    {
        var myList = new List<A> { new A(), new B(), new C() };
        foreach (var a in myList)
        {
            a.Render();
        }
        Console.ReadKey();
    }
