    public class Derived : Base {
        // public Derived() { } wouldn't work - what should be given for i?
        public Derived() : base(7) {
            Console.WriteLine("The value is " + 7);
        }
        public Derived(int i) : base(i) {
            Console.WriteLine("The value is " + i);
        }
    }
