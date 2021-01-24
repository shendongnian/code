    using System;
    
    class Test
    {
        // All this code is awful. PURELY FOR DEMONSTRATION PURPOSES.
        public static Test operator==(Test lhs, Test rhs) => new Test();
        public static Test operator!=(Test lhs, Test rhs) => new Test();
        public static string operator!(Test lhs) => "Negated";
        public override string ToString() => "Not negated";
        
        public override bool Equals(object other) => true;
        public override int GetHashCode() => 0;
        
        static void Main()
        {
            Test a = null;
            Test b = null;
            Console.WriteLine(a != b);    // "Not negated"
            Console.WriteLine(!(a == b)); // "Negated"
        }    
    }
