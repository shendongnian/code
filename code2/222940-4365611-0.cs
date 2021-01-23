    using System;
    class Program {
        static void Main() {
            int i = Add(3, 5); // prints: int overload called
            double d = Add(3, 5); // prints: double overload called
        }
        static SuperMagicAdder Add(int a, int b)
        { return new SuperMagicAdder(a, b); }
    }
    struct SuperMagicAdder {
        private readonly int a,b;
        public SuperMagicAdder(int a, int b) { this.a = a; this.b = b; }
        public override string  ToString() { return a + "+" + b; }
        public static implicit operator int (SuperMagicAdder value) {
            Console.WriteLine("int overload called");
            return value.a + value.b;
        }
        public static implicit operator double (SuperMagicAdder value) {
            Console.WriteLine("double overload called");
            return (double)value.a + value.b;
        }
    }
