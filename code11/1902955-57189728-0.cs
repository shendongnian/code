    class Program
        {
            private static Int64 _segmentsQty;
            private static double _step;
            private static Random _random = new Random();
    
            static void Main()
            {
                InclusiveRandomPrep();
                for (int i = 1; i < 20; i++)
                {
                    Console.WriteLine(InclusiveRandom());
                }
    
                Console.ReadLine();
            }
    
            public static void InclusiveRandomPrep()
            {
                _segmentsQty = (Int64)int.MaxValue - int.MinValue;
                _step = 1.0 / _segmentsQty;
            }
            public static int InclusiveRandom()
            {
                var randomDouble = _random.NextDouble();
                var times = randomDouble / _step;
                var result = (Int64)Math.Floor(times);
                return (int)result + int.MinValue;
            }
        }
