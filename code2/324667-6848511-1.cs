    class Foo
    {
        private readonly Foo _foo = new Foo(); // Valid
        
        public Foo()
        {
            _foo = new Foo(); // Valid
        }
        
        private void SomeMethod()
        {
            _foo = new Foo(); // Not valid
        }
    }
