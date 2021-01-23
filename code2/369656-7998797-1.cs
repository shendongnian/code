    using System;
    
    class Weird
    {
        private readonly int amount;
        
        public Weird(int amount)
        {
            this.amount = amount;
        }
        
        private int Add(int original)
        {
            return original + amount;
        }
        
        // Very strange. Please don't do this.
        public static Func<int, int> operator +(Weird weird)
        {
            return weird.Add;
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            Weird weird = new Weird(2);
            Func<int, int> func = +weird;
            Console.WriteLine(func(3));
        }
    }
