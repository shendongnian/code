    public class Bar
    { 
        private Foo foo;
        public Bar(Foo foo) => this.foo = foo ?? throw new ArgumentNullException(nameof(foo));
    
        public void Main()
        {
            // Now we know it is not null and, for Bar, it does not matter whether it's a singleton or not.
            foo.Method1();
        }
    }
