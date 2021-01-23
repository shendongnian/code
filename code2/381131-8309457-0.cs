    class advanc
    {
        public virtual int calc(int a, int b)
        {
            Console.WriteLine("Base function called");
            return (a * b);
        }
    }
    
    class advn : advanc
    {
        public bool CallBase { get; set; }
        public override int calc(int a, int b)
        {
            Console.WriteLine("Override function called");
    
            if (CallBase)
            {
                return base.calc(a, b);
            }
            else
            {
                return a / b;
            }
        }
    }
    
    private static void Main()
    {
        advn a = new advn();
        
        a.CallBase = true;
        int result = a.calc(10, 2);
        Console.WriteLine(result);
        
        a.CallBase = false;
        result = a.calc(10, 2);
        Console.WriteLine(result);
        Console.WriteLine("Ready");
        Console.ReadKey();
    }
