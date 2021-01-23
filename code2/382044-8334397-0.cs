        public static long ClosedFormFibonacci(int i)
        {
            const double phi = 1.61803398874989; // or use your own or calculate it
            const double sqrt5 = 2.23606798; // same as above
            return (long)Math.Round(Math.Pow(phi, i) / sqrt5);
        }
