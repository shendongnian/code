    using System;
    
    class Test
    {
        // All this code is awful. PURELY FOR DEMONSTRATION PURPOSES.
        public static bool operator==(Test lhs, Test rhs) => true;
        public static bool operator!=(Test lhs, Test rhs) => true;        
        public override bool Equals(object other) => true;
        public override int GetHashCode() => 0;
        
        static void Main()
        {
            Test a = null;
            Test b = null;
            Console.WriteLine(a != b);    // True
            Console.WriteLine(!(a == b)); // False
        }    
    }
