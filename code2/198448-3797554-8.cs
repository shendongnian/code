    public class Derived : Base {
        // public Derived() { } wouldn't work - what should be given for i?
        public Derived() : this(7) { }
        public Derived(int i) : base(i) {
            Console.WriteLine("The value is " + i);
        }
    }
