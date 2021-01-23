    class Test
    {
        private static void Foo(Delegate d) { }
        private static void Bar(Action a) { }
        static void Main()
        {
            Foo(new Action(() => { Console.WriteLine("world2"); })); // Action converts to Delegate implicitly
            Bar(() => { Console.WriteLine("world3"); }); // lambda converts to Action implicitly
            Foo((Action)(() => { Console.WriteLine("world3"); })); // This compiles
        }
    }
