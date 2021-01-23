    using System;
    
    class ACType
    {
        public int Value { get; set; }
        
        public static implicit operator BType(ACType ac)
        {
            return new BType { Value = ac.Value / 2 };
        }
    }
    
    class BType
    {
        public int Value { get; set; }
        
        public static implicit operator ACType(BType b)
        {
            return new ACType { Value = b.Value / 2 };
        }
    }
    
    class Test
    {
        static void Main()
        {
            ACType a, c;
            BType b;
            
            c = new ACType { Value = 100 };
            a = b = c;
            
            Console.WriteLine(a.Value); // Prints 25
        }
    }
