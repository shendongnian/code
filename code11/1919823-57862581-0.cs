    class States
    {
        private static int Sum(int[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }
        private static double Average(int[] values)
        {
            int sum = Sum(values);
            double avg = (double)sum / values.Length;
            return avg;
        }
        //this is where i am having trouble
        public static double Variance(int[] values)
        {
            if (values.Length > 1)
            {
                double avg = Average(values);
                double variance = 0.0;
                foreach (int value in values)
                {
                    // Math.Pow to calculate variance? 
                    variance += Math.Pow(value - avg, 2.0);
                }
                return variance;
            }
            else
            {
                return 0.0;
            }
        }
        private static double StdDev(double var)
        {
            return Math.Sqrt(var);
        }
    }
