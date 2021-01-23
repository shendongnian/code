    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
      class CalculationException : Exception { }
      class Program
      {
        static double Calc1() { throw new CalculationException(); }
        static double Calc2() { throw new CalculationException(); }
        static double Calc3() { return 42.0; }
        static void Main(string[] args)
        {
          var methods = new List<Func<double>> {
            new Func<double>(Calc1),
            new Func<double>(Calc2),
            new Func<double>(Calc3)
        };
        double? result = null;
        foreach (var method in methods)
        {
          try {
            result = method();
            break;
          }
          catch (CalculationException ex) {
            // handle exception
          }
         }
         Console.WriteLine(result.Value);
       }
    }
