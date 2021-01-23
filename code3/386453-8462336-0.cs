    static class Extensions
    {
         public static IEnumerable<double> MovingAverage(this double[] numbers, int runs)
         {
             for (var i = 0; i < numbers.Length - runs + 1; i++)
                 yield return Enumerable.Range(i, runs).Average(idx => numbers[idx]);
         }
    }
