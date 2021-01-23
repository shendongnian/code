    interface IFoo { void Bar(); }
    public class Foo : IFoo {
        public void Bar() { Console.WriteLine("Foo.Bar!"); }
        public void Baz() { Console.WriteLine("Baz!"); }
    }
