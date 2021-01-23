    class Program
    {
        private static int NaNComparison(double first, double second)
        {
            if (double.IsNaN(first))
            {
                if (double.IsNaN(second)) // Throws an argument exception if we don't handle both being NaN
                    return 0;
                else
                    return -1;
            }
            if (double.IsNaN(second))
                return 1;
            if (first == second)
                return 0;
            return first < second ? -1 : 1;
        }
        static void Main(string[] args)
        {
            var doubles = new[] { double.NaN, 2.0, 3.0, 1.0, double.NaN };
            Array.Sort(doubles, NaNComparison);
        }
    }
