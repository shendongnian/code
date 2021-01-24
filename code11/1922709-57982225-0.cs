Forward:  18000, Keys: 500,01, 500,02
Backward: 17000, Keys: 499,98, 499,99
Backward: 14000, Keys: 499,96, 499,97
Forward:  13000, Keys: 500,03, 500,04
What might be going wrong is that your Main method is not static neither are the mainsd and valuesd fields. This would not create an index out of bounds exception though. The piece of code you supplied worked perfectly fine. Just in case here is the code that I ended up with
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace AProgramNamespace
{
    class Program
    {
        private static SortedDictionary<double, int> mainsd = new SortedDictionary<double, int>();
        private static SortedDictionary<double, int> valuesd = new SortedDictionary<double, int>();
        protected static void Main()
        {
            mainsd = new SortedDictionary<double, int>()
              {
                  {500.10, 500}, {500.09, 1000}, {500.08, 2000}, {500.07, 3000},
                  {500.06, 4500}, {500.05, 5500}, {500.04, 6000}, {500.03, 7000},
                  {500.02, 8500}, {500.01, 9500}, {500.00, 10000}, {499.99, 9000},
                  {499.98, 8000}, {499.97, 7500}, {499.96, 6500}, {499.95, 5000},
                  {499.94, 4000}, {499.93, 3500}, {499.92, 2500}, {499.91, 1500},
                  {499.90, 550},
              };
            var maxValue = mainsd.Max(e => e.Value);
            var maxItemKey = mainsd.First(e => e.Value == maxValue).Key;
            var forward = mainsd.SkipWhile(e => e.Key <= maxItemKey).ToArray();
            var backward = mainsd.TakeWhile(e => e.Key < maxItemKey).Reverse().ToArray();
            int i1 = 0;
            int i2 = 0;
            while (true)
            {
                var sum1 = i1 < forward.Length - 1 ? forward[i1].Value + forward[i1 + 1].Value : 0;
                var sum2 = i2 < backward.Length - 1 ? backward[i2].Value + backward[i2 + 1].Value : 0;
                if (sum1 == 0 && sum2 == 0) break;
                if (sum1 >= sum2)
                {
                    valuesd.Add(forward[i1].Key, forward[i1].Value);
                    valuesd.Add(forward[i1 + 1].Key, forward[i1 + 1].Value);
                    Console.WriteLine($"Forward:  {sum1}, Keys: {forward[i1].Key}, {forward[i1 + 1].Key}");
                    i1 += 2;
                }
                else
                {
                    valuesd.Add(backward[i2].Key, backward[i2].Value);
                    valuesd.Add(backward[i2 + 1].Key, backward[i2 + 1].Value);
                    Console.WriteLine($"Backward: {sum2}, Keys: {backward[i2 + 1].Key}, {backward[i2].Key}");
                    i2 += 2;
                }
                if (valuesd.Values.Sum() >= mainsd.Values.Sum() * 50 / 100) break;
            }
        }
    }
}
