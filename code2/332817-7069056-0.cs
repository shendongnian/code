    class Foo {
        public void M(Delegate d) {
            d.DynamicInvoke();
        }
    }
    Action action = () => Console.WriteLine("Hello, world!");
    var foo = new Foo();
    foo.M(action);
