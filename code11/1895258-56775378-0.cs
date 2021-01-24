    public interface IFoo
    {
        string Bar(string parameter);
        string Bar();
    }
    public class Foo : IFoo
    {
        public string Bar(string parameter)
        {
            return string.Format("{0}Fooooooo", parameter);
        }
        public string Bar()
        {
            return string.Empty;
        }
    }
    public class ConstantFoo : IFoo
    {
        public string Bar(string parameter)
        {
            return string.Empty;
        }
        public string Bar()
        {
            return "Baaaaaaar";
        }
    }
    public class Caller
    {
        private readonly IFoo _foo;
        private readonly IFoo _constFoo;
        public Caller()
        {
            _foo = new Foo();
            _constFoo = new ConstantFoo();
        }
        public void DummyUsage()
        {
            string arg = "Wololo";
            Console.WriteLine(_foo.Bar(arg));
            Console.WriteLine(_constFoo.Bar());
        }
    }
