    using System;
    using System.Diagnostics;
    public static class StringFormattingPerformance
    {
       public static void Main()
       {
          Console.WriteLine("C# String Formatting Performance");
          Console.WriteLine("Milliseconds Per 1 Million Iterations - Best Of 5");
          long stringInterpolationBestOf5 = Measure1MillionIterationsBestOf5(
              (double randomDouble) =>
              {
                 return $"{randomDouble:0.##}";
              });
          long stringDotFormatBestOf5 = Measure1MillionIterationsBestOf5(
              (double randomDouble) =>
              {
                 return string.Format("{0:0.##}", randomDouble);
              });
          long valueDotToStringBestOf5 = Measure1MillionIterationsBestOf5(
              (double randomDouble) =>
              {
                 return randomDouble.ToString("0.##");
              });
          Console.WriteLine(
    $@"            $""{{value:formatString}}"": {stringInterpolationBestOf5} ms
     string.Format(formatString, value): {stringDotFormatBestOf5} ms
           value.ToString(formatString): {valueDotToStringBestOf5} ms");
       }
       private static long Measure1MillionIterationsBestOf5(
           Func<double, string> formatDoubleUpToTwoDecimalPlaces)
       {
          long elapsedMillisecondsBestOf5 = long.MaxValue;
          for (int perfRunIndex = 0; perfRunIndex < 5; ++perfRunIndex)
          {
             var random = new Random();
             var stopwatch = Stopwatch.StartNew();
             for (int i = 0; i < 1000000; ++i)
             {
                double randomDouble = random.NextDouble();
                formatDoubleUpToTwoDecimalPlaces(randomDouble);
             }
             stopwatch.Stop();
             elapsedMillisecondsBestOf5 = Math.Min(
                elapsedMillisecondsBestOf5, stopwatch.ElapsedMilliseconds);
          }
          return elapsedMillisecondsBestOf5;
       }
    }
