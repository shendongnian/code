    class Program
    {
        public static Random _random = new Random();
        static void Main(string[] args)
        {
            List<List<double>> population = new List<List<double>>();
            for (int k = 0; k < 100; k++)
            {
                var gWeights = new List<double>();
                for (int i = 0; i < 60; i++)
                {
                    var random = (_random.NextDouble() * 2) - 1;
                    gWeights.Add(random);
                }
                population.Add(gWeights);
            }
            List<double> population2 = new List<double>();
            population.ForEach(x => population2.AddRange(x));
            GetResult(population2);
            Console.ReadKey();
        }
        public static void GetResult(List<double> items)
        {
            //your code
        }
    }
