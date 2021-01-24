        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", GetTicksBetweenNumbersBySteps(1000, 213, 4405)));
            Console.WriteLine(string.Join(",", GetTicksBetweenNumbersBySteps(500, -1213, 1405)));
        }
        private static List<int> GetTicksBetweenNumbersBySteps(int stepsize, int min, int max)
        {
            List<int> foundTicks = new List<int>() { 0 };
            int actualTick = 0;
            while (actualTick > min)
            {
                actualTick -= stepsize;
                if (actualTick >= min)
                {
                    foundTicks.Add(actualTick);
                }
            }
            actualTick = 0;
            while (actualTick < max)
            {
                actualTick += stepsize;
                if (actualTick <= max)
                {
                    foundTicks.Add(actualTick);
                }
            }
            return foundTicks.OrderBy(x => x).ToList();
        }
