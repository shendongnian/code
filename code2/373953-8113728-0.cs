    using System;
    
    class Program
    {
      public static void Main()
      {
        long x = 4746073226998689451;
        decimal sqrt_x = (decimal)Math.Sqrt(x);
        for (int i = 0; i < 10; ++i)
          sqrt_x = 0.5m * (sqrt_x + x / sqrt_x);
        Console.WriteLine("{0:F16}", sqrt_x);
      }
    }
