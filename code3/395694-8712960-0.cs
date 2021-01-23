        private static Random RandomGenerator = new Random(0x42);
    
        private static string Generate()
        {
            double value = RandomGenerator.NextDouble() * 100;
    
            if (value < 30)
            {
                return "A";
            }
            else if (value < 44)
            {
                return "B";
            }
            else
            {
                return "C";
            }
        }
