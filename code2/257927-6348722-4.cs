using System;
using System.Collections.Generic;
using System.Linq;
namespace Financial
{
    public class Program
    {
        private const double DaysPerYear = 365.0;
        public static void Main(string[] args)
        {
            CashItem[] cashItems =
                {
                    new CashItem(new DateTime(2001, 5, 1), 10000),
                    new CashItem(new DateTime(2002, 3, 1), 2000),
                    new CashItem(new DateTime(2002, 5, 1), -5500),
                    new CashItem(new DateTime(2002, 9, 1), 3000),
                    new CashItem(new DateTime(2003, 2, 1), 3500),
                    new CashItem(new DateTime(2003, 5, 1), -15000),
                };
            var positiveItemsCount = cashItems.Count(c => c.Amount > 0);
            if (positiveItemsCount == 0)
                throw new ArgumentException("Add at least one positive item");
            var negativeItemsCount = cashItems.Count(c => c.Amount < 0);
            if (negativeItemsCount == 0)
                throw new ArgumentException("Add at least one negative item");
            // Hard-coded: based on Excel doc (http://office.microsoft.com/en-us/excel-help/xirr-function-HP010062387.aspx)
            const double defaultTolerance = 0.000001;
            const double defaultGuess = 0.1;
            var result = CalcXirr(cashItems, defaultGuess, defaultTolerance);
            if (Double.IsInfinity(result) || Double.IsNaN(result))
                throw new InvalidOperationException("Could not calculate XIRR: Infinity");
            if (Double.IsNaN(result))
                throw new InvalidOperationException("Could not calculate XIRR: Not a number");
            Console.WriteLine("XIRR value is {0}", result);
        }
        private static double CalcXirr(IList<CashItem> cashItems, double guess, double tolerance)
        {
            // see: http://gautam.satpathy.org/software/java/jxirr
            // Hard-coded: based on Excel doc (http://office.microsoft.com/en-us/excel-help/xirr-function-HP010062387.aspx)
            const int maxIterations = 100;
            var x0 = guess;
            var i = 0;
            bool continueLoop;
            do
            {
                var fx0 = XirrFunction(cashItems, x0);
                var xstep = Math.Abs(x0)/1e6;
                var dfx0 = XirrDerivative(XirrFunction, cashItems, x0, xstep);
                double x1;
                // Overshoot slightly to prevent us from staying on just one side of the root.
                if (Math.Abs(Math.Abs(dfx0) - 0) >= double.Epsilon)
                    x1 = x0 - 1.000001*fx0/dfx0;
                else
                    x1 = x0/2;
                var errorEstimate = Math.Abs(x1 - x0)/(Math.Abs(x0) + Math.Abs(x1));
                x0 = x1;
                continueLoop = errorEstimate > tolerance && Math.Abs(fx0) > tolerance;
            } while (continueLoop && ++i < maxIterations);
            if (continueLoop || i == maxIterations)
                return double.NaN;
            var result = x0 < 0 ? -1*(1 + x0) : x0 - 1;
            return result;
        }
        private static double XirrFunction(IList<CashItem> cashItems, double rate)
        {
            var firstEntry = cashItems.First();
            var firstDate = firstEntry.Date;
            var result = 0.0d;
            for (var i = 0; i < cashItems.Count(); i++)
            {
                var entry = cashItems.ElementAt(i);
                var days = (entry.Date - firstDate).Days;
                if (days < 0)
                    return double.NaN;
                result += entry.Amount/Math.Pow(rate, days/DaysPerYear);
            }
            return result;
        }
        private static double XirrDerivative(Func<IList<CashItem>, double, double> xirrFunction,
                                             IList<CashItem> cashItems,
                                             double x,
                                             double xStep)
        {
            var xLeft = x - xStep;
            if (xLeft < double.MinValue)
                xLeft = x;
            var xRight = x + xStep;
            if (xRight > double.MaxValue)
                xRight = x;
            if (Math.Abs(xLeft - xRight) < double.Epsilon)
                return double.NaN;
            var yLeft = xirrFunction(cashItems, xLeft);
            var yRight = xirrFunction(cashItems, xRight);
            var dfx = (yRight - yLeft)/(xRight - xLeft);
            return dfx;
        }
    }
    public struct CashItem
    {
        public DateTime Date;
        public double Amount;
        public CashItem(DateTime date, double amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}
The results seem to match the ones obtained in Excel. See document on [Excel XIRR][1].
[1]: http://office.microsoft.com/en-us/excel-help/xirr-function-HP010062387.aspx
