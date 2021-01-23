    public class FooFoo : IFoo {
        public void Bar() { Console.WriteLine("FooFoo.Bar!"); }
    }
    IFoo foofoo = new FooFoo();
    foofoo.Baz(); // not legal
