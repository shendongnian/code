    namespace Test
    {
        using System;
        using System.Linq;
        internal class TestCompile
        {
            private static void Main(string[] args)
            {
                var objectList = Enumerable.Range(0, 3).Select(i => new { ID = i, DecimalValue = i / 5.0m }).ToList();
                decimal result = objectList.Any() ? objectList.Distinct().Sum(x => x.DecimalValue) : 0;
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }
