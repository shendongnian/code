    using System;
    
    class A : IComparable
    {
        private readonly int value;
        
        public A(int value)
        {
            this.value = value;
        }
        
        public int CompareTo(object other)
        {
            // Just cast for now...
            return value.CompareTo(((A)other).value);
        }
    }
    
    class Test
    {
        static void Main()
        {
            object[] objects = { new A(5), new A(3), new A(4) };
            Array.Sort<object>(objects);
        }
    }
