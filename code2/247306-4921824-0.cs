    interface IRenderable
    {
        AcceptForRender(Program renderer);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            var myList = new List<IRenderable> {new A(), new B(), new C()};
            foreach (var a in myList)
            {
                a.AcceptForRender(p);
            }
            Console.ReadKey();
        }
        public void Render(A o)
        {
            Console.Write("A");
        }
        public void Render(B b)
        {
            Console.Write("B");
        }
        public void Render(C c)
        {
            Console.Write("C");
        }
    }
    class A : IRenderable
    {
        public void AcceptForRender(Program renderer)
        {
            renderer.Render(this);
        }
    }
    class B : IRenderable
    {
        public void AcceptForRender(Program renderer)
        {
            renderer.Render(this);
        }
    }
    class C : IRenderable
    {
        public void AcceptForRender(Program renderer)
        {
            renderer.Render(this);
        }
    }
