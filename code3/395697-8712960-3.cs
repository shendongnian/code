        // You can provide a seed as a parameter of the Random() class.
        private static Random RandomGenerator = new Random();
    
        private static string Generate()
        {
            int value = RandomGenerator.Next(100);
    
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
