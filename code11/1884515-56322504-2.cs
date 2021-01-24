    class Program
    {
        static void Main(string[] args)
        {
            double l = CalculateL(10, 100);
            double notRecursiveL = NotRecursiveCalculateL(10, 100);
        }
        private static double CalculateL(double p, int maxSteps)
        {
            if (maxSteps == 0)
            {
                return (1 / (p + 1));
            }
            else
            {
                return (1 / (p + CalculateL(p, maxSteps - 1)));
            }
        }
        private static double NotRecursiveCalculateL(double p, int maxSteps)
        {
            double result = 0;
            for (int i = 0; i < maxSteps; i++)
            {
                result = (1 / (p + result));
            }
            return result;
        }
    }
