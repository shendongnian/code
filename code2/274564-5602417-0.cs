    class Program
    {
        static void Main(string[] args)
        {
            var target = 87;
            var current = 0;
            var dollarSizes = new[] { 1, 5, 10, 20 }.OrderByDescending(x => x); // just make sure they're descending.
            var bestWay = new List<int>();
    
            foreach (var dollarSize in dollarSizes)
            {
                while (current + dollarSize <= target)
                {
                    current += dollarSize;
                    bestWay.Add(dollarSize);
                }
    
                if (current == target)
                    break;
            }
    
            foreach (var dollar in bestWay)
            {
                Console.Write("{0}, ", dollar);
            }
    
            Console.ReadLine();
        }
    }
