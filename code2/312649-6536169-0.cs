    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    namespace Currency
    {
        struct Money
        {          
            decimal innerValue;
            public static implicit operator Money(decimal value)
            {
                return new Money { innerValue = value };
            }
            public static explicit operator decimal(Money value)
            {
                return value.innerValue;
            }
            public static Money Parse(string s)
            {
            return decimal.Parse(s);
            }
         }
         class Program
         {
             static void Main()
             {
                 var source = new[] { "2" };
                 Money thisWorks = source.Sum(x => Money.Parse(x));
                 int thisWorksToo = 
                     source.Sum(new Func<string, int>(x => int.Parse(x)));       
                 int thisWorksTooNow = source.Sum(x => int.Parse(x));
             }
         }
    }
    namespace Extensions
    {
        static class IEnumerableTExtensions
        {
            public static Currency.Money Sum<TSource>(
                                           this IEnumerable<TSource> source,
                                           Func<TSource, Currency.Money> selector)
            {
                return source.Select(x => (decimal)selector(x)).Sum();
            }
        }
    }
