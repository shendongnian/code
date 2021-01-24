    // original libary code
    public class BaseClass
    {
        public string Method1() => "m1 of base";
        public string Method2() => "m2 of base";
    }
    public class A : BaseClass
    {
        public string Method1() => "m1 A";
        public string Method2() => "m2 A";
    }
    public class B : BaseClass
    {
        public string Method1() => "m1 B";
        public string Method2() => "m2 B";
    }
    public class C : BaseClass
    {
        public string Method1() => "m1 C";
        public string Method2() => "m2 C";
    }
    // methods to be overridden
    public interface IMethodOfBase
    {
        void Method1();
        void Method2();
    }
    // common behaviour
    public class Decorator:IMethodOfBase
    {
        private BaseClass b;
        public Decorator(BaseClass b)
        {
            this.b = b;
        }
        public void Method1()
        {
            Console.WriteLine($"overridden behaviour in one place {b.Method1()}");
        }
        public void Method2()
        {
            Console.WriteLine($"overridden behaviour in one place {b.Method2()}");
        }
    }
    // example usage
    public class WorkLoad
    {
        private List<Decorator> _work; 
        
        public WorkLoad()
        {
            _work = new List<Decorator>
            {
                new Decorator(new A()),
                new Decorator(new B()),
                new Decorator(new C()) //etc
            };
        }
        public void DoWork()
        {
            _work.ForEach( n =>
            {
                n.Method1();
                n.Method2();
            });
        }
        
    }
