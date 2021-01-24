    public class Foo
    {
        public static Foo Invoker { get; } = new Foo();
        // Private constructor makes sure the only instance of Foo is created here.
        private Foo()
        {
        }
    }
