    class Program
    {
        static void Main(string[] args)
        {
            double l = CalculateL(10, 100);
        }
        private static double CalculateL(double p, int maxSteps)
        {
            if(maxSteps == 0)
            {
                return (1 / (p + 1));
            }
            else
            {
                return (1 / (p + CalculateL(p, maxSteps - 1)));
            }
        }
    }
