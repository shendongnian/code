    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Financial
    {
        public class Program
        {
            public const double Tolerance = 0.001;
            private const double Guess = 0.1;
            private const double DaysPerYear = 365.0;
            private delegate double fx(double x);
            public static void Main(string[] args)
            {
                CashItem[] cashItems = {
                                           new CashItem(new DateTime(2001, 5, 1), 10000),
                                           new CashItem(new DateTime(2002, 3, 1), 2000),
                                           new CashItem(new DateTime(2002, 5, 1), -5500),
                                           new CashItem(new DateTime(2002, 9, 1), 3000),
                                           new CashItem(new DateTime(2003, 2, 1), 3500),
                                           new CashItem(new DateTime(2003, 5, 1), -15000),
                                       };
                var xirr = Xirr(cashItems);
                Console.WriteLine("XIRR value is {0}", xirr);
            }
            public static double Xirr(IList<CashItem> cashItems)
            {
                var firstItem = cashItems[0];
                fx seed = x => 0.0;
                var fxTotal = cashItems.Aggregate(seed, (current, cashItem) => Compose(current, f(cashItem, firstItem)));
                var dfxTotal = cashItems.Aggregate(seed, (current, cashItem) => Compose(current, df(cashItem, firstItem)));
                
                var xirr = NewtonsMethod(fxTotal, dfxTotal, Guess);
                return xirr;
            }
            private static fx f(CashItem cashItem, CashItem firstItem)
            {
                var totalDays = firstItem.Date.Subtract(cashItem.Date).TotalDays;
                return x => cashItem.Amount*Math.Pow((1.0 + x), totalDays/DaysPerYear);
            }
            private static fx df(CashItem cashItem, CashItem firstItem)
            {
                var totalDays = firstItem.Date.Subtract(cashItem.Date).TotalDays;
                return x => (1.0/DaysPerYear)*totalDays*cashItem.Amount*Math.Pow((x + 1.0), ((totalDays/DaysPerYear) - 1.0));
            }
            private static double NewtonsMethod(fx f, fx df, double guess)
            {
                var x0 = guess;
                var err = 1e+100;
                while (err > Tolerance)
                {
                    var x1 = x0 - f(x0)/df(x0);
                    err = Math.Abs(x1 - x0);
                    x0 = x1;
                }
                return x0;
            }
            private static fx Compose(fx f1, fx f2)
            {
                return x => f1(x) + f2(x);
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
