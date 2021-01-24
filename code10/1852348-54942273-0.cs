    class Program
    {
        static void Main(string[] args)
        {
            FakeClass.MyCostA = 123;
            var x = FakeClass.CompareCosts(FakeClass.MyCostA);
    
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
    
    public static class FakeClass {
        public static decimal MyCostA { get; set; }
        public static decimal MyCostB { get; set; }
    
            public static string CompareCosts(decimal cost)
            {
                return cost == MyCostA ? "same property" : "not same property";
            }
    }
