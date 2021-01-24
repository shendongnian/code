using System;
using System.Collections.Generic;
using System.Linq;
namespace CarFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.Write(String.Join(" ", BlackBox(numbers)) + " " + -1);
        }
        private static int[] BlackBox(int[] numbers)
        {
            Dictionary<int, int> carPrices = new Dictionary<int, int>();
            carPrices.Add(0, 0);
            carPrices.Add(1, 150);
            carPrices.Add(2, 50);
            carPrices.Add(3, 125);
            carPrices.Add(4, 25);
            carPrices.Add(5, 20);
            carPrices.Add(6, 30);
            Dictionary<int, int> totals = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i += 2)
            {
                int key = numbers[i];
                if (key == -1)
                    break;
                int priceKey = numbers[i + 1];
                if (totals.ContainsKey(key))
                    totals[key] += carPrices[priceKey];
                else
                    totals[key] = carPrices[priceKey];
            }
            return new SortedDictionary<int, int>(totals)
                .Select(e => 1000 + e.Value)
                .TakeWhile(x => x != -1)
                .ToArray();
        }
    }
}
