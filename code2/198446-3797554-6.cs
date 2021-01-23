    public class Base {
        public Base(int i) { }
    }
    
    public class Derived : Base {
        // public Derived() { } wouldn't work - what should be given for i?
        public Derived() : base(7) { }
        public Derived(int i) : base(i) { }
    }
