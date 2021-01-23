using System;
using System.Collections.Generic;
using System.Linq;
// See the following articles:
//   http://blogs.msdn.com/b/lucabol/archive/2007/12/17/bisection-based-xirr-implementation-in-c.aspx
//   http://www.codeproject.com/Articles/79541/Three-Methods-for-Root-finding-in-C
//   http://www.financialwebring.org/forum/viewtopic.php?t=105243&highlight=xirr
// Default values based on Excel doc 
//   http://office.microsoft.com/en-us/excel-help/xirr-function-HP010062387.aspx
namespace Xirr
{
    public class Program
    {
        private const Double DaysPerYear = 365.0;
        private const int MaxIterations = 100;
        private const double DefaultTolerance = 1E-6;
        private const double DefaultGuess = 0.1;
        private static readonly Func<IEnumerable<CashItem>, Double> NewthonsMethod =
            cf => NewtonsMethodImplementation(cf, Xnpv, XnpvPrime);
        private static readonly Func<IEnumerable<CashItem>, Double> BisectionMethod =
            cf => BisectionMethodImplementation(cf, Xnpv);
        public static void Main(string[] args)
        {
            RunScenario(new[]
                {
                    // this scenario fails with Newton's but succeeds with slower Bisection
                    new CashItem(new DateTime(2012, 6, 1), 0.01),
                    new CashItem(new DateTime(2012, 7, 23), 3042626.18),
                    new CashItem(new DateTime(2012, 11, 7), -491356.62),
                    new CashItem(new DateTime(2012, 11, 30), 631579.92),
                    new CashItem(new DateTime(2012, 12, 1), 19769.5),
                    new CashItem(new DateTime(2013, 1, 16), 1551771.47),
                    new CashItem(new DateTime(2013, 2, 8), -304595),
                    new CashItem(new DateTime(2013, 3, 26), 3880609.64),
                    new CashItem(new DateTime(2013, 3, 31), -4331949.61)
                });
            RunScenario(new[]
                {
                    new CashItem(new DateTime(2001, 5, 1), 10000),
                    new CashItem(new DateTime(2002, 3, 1), 2000),
                    new CashItem(new DateTime(2002, 5, 1), -5500),
                    new CashItem(new DateTime(2002, 9, 1), 3000),
                    new CashItem(new DateTime(2003, 2, 1), 3500),
                    new CashItem(new DateTime(2003, 5, 1), -15000)
                });
        }
        private static void RunScenario(IEnumerable<CashItem> cashFlow)
        {
            try
            {
                try
                {
                    var result = CalcXirr(cashFlow, NewthonsMethod);
                    Console.WriteLine("XIRR [Newton's] value is {0}", result);
                }
                catch (InvalidOperationException)
                {
                    // Failed: try another algorithm
                    var result = CalcXirr(cashFlow, BisectionMethod);
                    Console.WriteLine("XIRR [Bisection] (Newton's failed) value is {0}", result);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private static double CalcXirr(IEnumerable<CashItem> cashFlow, Func<IEnumerable<CashItem>, double> method)
        {
            if (cashFlow.Count(cf => cf.Amount > 0) == 0)
                throw new ArgumentException("Add at least one positive item");
            if (cashFlow.Count(c => c.Amount < 0) == 0)
                throw new ArgumentException("Add at least one negative item");
            var result = method(cashFlow);
            
            if (Double.IsInfinity(result))
                throw new InvalidOperationException("Could not calculate: Infinity");
            if (Double.IsNaN(result))
                throw new InvalidOperationException("Could not calculate: Not a number");
            return result;
        }
        private static Double NewtonsMethodImplementation(IEnumerable<CashItem> cashFlow,
                                                          Func<IEnumerable<CashItem>, Double, Double> f,
                                                          Func<IEnumerable<CashItem>, Double, Double> df,
                                                          Double guess = DefaultGuess,
                                                          Double tolerance = DefaultTolerance,
                                                          int maxIterations = MaxIterations)
        {
            var x0 = guess;
            var i = 0;
            Double error;
            do
            {
                var dfx0 = df(cashFlow, x0);
                if (Math.Abs(dfx0 - 0) < Double.Epsilon)
                    throw new InvalidOperationException("Could not calculate: No solution found. df(x) = 0");
                var fx0 = f(cashFlow, x0);
                var x1 = x0 - fx0/dfx0;
                error = Math.Abs(x1 - x0);
                x0 = x1;
            } while (error > tolerance && ++i < maxIterations);
            if (i == maxIterations)
                throw new InvalidOperationException("Could not calculate: No solution found. Max iterations reached.");
            return x0;
        }
        internal static Double BisectionMethodImplementation(IEnumerable<CashItem> cashFlow,
                                                             Func<IEnumerable<CashItem>, Double, Double> f,
                                                             Double tolerance = DefaultTolerance,
                                                             int maxIterations = MaxIterations)
        {
            // From "Applied Numerical Analysis" by Gerald
            var brackets = Brackets.Find(Xnpv, cashFlow);
            if (Math.Abs(brackets.First - brackets.Second) < Double.Epsilon)
                throw new ArgumentException("Could not calculate: bracket failed");
            Double f3;
            Double result;
            var x1 = brackets.First;
            var x2 = brackets.Second;
            var i = 0;
            do
            {
                var f1 = f(cashFlow, x1);
                var f2 = f(cashFlow, x2);
                if (Math.Abs(f1) < Double.Epsilon && Math.Abs(f2) < Double.Epsilon)
                    throw new InvalidOperationException("Could not calculate: No solution found");
                if (f1*f2 > 0)
                    throw new ArgumentException("Could not calculate: bracket failed for x1, x2");
                result = (x1 + x2)/2;
                f3 = f(cashFlow, result);
                if (f3*f1 < 0)
                    x2 = result;
                else
                    x1 = result;
            } while (Math.Abs(x1 - x2)/2 > tolerance && Math.Abs(f3) > Double.Epsilon && ++i < maxIterations);
            if (i == maxIterations)
                throw new InvalidOperationException("Could not calculate: No solution found");
            return result;
        }
        private static Double Xnpv(IEnumerable<CashItem> cashFlow, Double rate)
        {
            if (rate <= -1)
                rate = -1 + 1E-10; // Very funky ... Better check what an IRR <= -100% means
            var startDate = cashFlow.OrderBy(i => i.Date).First().Date;
            return
                (from item in cashFlow
                 let days = -(item.Date - startDate).Days
                 select item.Amount*Math.Pow(1 + rate, days/DaysPerYear)).Sum();
        }
        private static Double XnpvPrime(IEnumerable<CashItem> cashFlow, Double rate)
        {
            var startDate = cashFlow.OrderBy(i => i.Date).First().Date;
            return (from item in cashFlow
                    let daysRatio = -(item.Date - startDate).Days/DaysPerYear
                    select item.Amount*daysRatio*Math.Pow(1.0 + rate, daysRatio - 1)).Sum();
        }
        public struct Brackets
        {
            public readonly Double First;
            public readonly Double Second;
            public Brackets(Double first, Double second)
            {
                First = first;
                Second = second;
            }
            internal static Brackets Find(Func<IEnumerable<CashItem>, Double, Double> f,
                                          IEnumerable<CashItem> cashFlow,
                                          Double guess = DefaultGuess,
                                          int maxIterations = MaxIterations)
            {
                const Double bracketStep = 0.5;
                var leftBracket = guess - bracketStep;
                var rightBracket = guess + bracketStep;
                var i = 0;
                while (f(cashFlow, leftBracket)*f(cashFlow, rightBracket) > 0 && i++ < maxIterations)
                {
                    leftBracket -= bracketStep;
                    rightBracket += bracketStep;
                }
                return i >= maxIterations
                           ? new Brackets(0, 0)
                           : new Brackets(leftBracket, rightBracket);
            }
        }
        public struct CashItem
        {
            public DateTime Date;
            public Double Amount;
            public CashItem(DateTime date, Double amount)
            {
                Date = date;
                Amount = amount;
            }
        }
    }
}
