    class Program
    {
        static void Main(string[] args)
        {
            var goldMine1 = new GoldMine() { Gold = 50 };
            var goldMine2 = new GoldMine() { Gold = 50 };
        }
    }
    class GoldMine
    {
        public int Gold { get; set; }
    }
