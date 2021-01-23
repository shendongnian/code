    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Median
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mediaValue = 0.0;
                var items = new[] { 1, 2, 3, 4,5 };
                var getLengthItems = items.Length;
                Array.Sort(items);
                if (getLengthItems % 2 == 0)
                {
                    var firstValue = items[(items.Length / 2) - 1];
                    var secondValue = items[(items.Length / 2)];
                    mediaValue = (firstValue + secondValue) / 2.0;
                }
                if (getLengthItems % 2 == 1)
                {
                    mediaValue = items[(items.Length / 2)];
                }
                Console.WriteLine(mediaValue);
                Console.WriteLine("Enter to Exit!");
                Console.ReadKey();
            }
        }
    }
