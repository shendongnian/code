    static class Foo {
        public void Member1() { /* ... */ }
        public void Member2() { /* ... */ }
        public void Member3() { /* ... */ }
    }
    static class FooPlus {
        public void Member1()
        {
            Foo.Member1();
        }
        // Repeat for all other methods
        // ...
        public void Member4() { /* ... */ }
    }
