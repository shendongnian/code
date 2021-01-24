    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication118
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                string input =
                    "ABC DEF GHI JKL\n" +
                    "A0 1 NaN 3.7 4\n" +
                    "A1 5 6.2 7 8\n" +
                    "A2 9 NaN 7 6\n" +
                    "B0 NaN 4 3.5 2\n" +
                    "B1 1 2 3 4\n" +
                    "B2 5.3 6 7 8\n" +
                    "C0 9 10 NaN 8\n" +
                    "C1 7 6.7 5 NaN\n" +
                    "C2 3 2 1.9 2\n";
                StringReader reader = new StringReader(input);
                List<Data> data = new List<Data>();
                string line = "";
                int rowCount = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (rowCount++ >= 1)
                    {
                        line = line.Trim();
                        if (line.Length > 0)
                        {
                            Data newData = new Data();
                            data.Add(newData);
                            string[] splitLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                            newData.name = splitLine[0];
                            decimal?[] numbers = splitLine.Skip(1).Select(x => (x == "NaN") ? null : (decimal?)decimal.Parse(x)).ToArray();
                            decimal average = (decimal)numbers.Sum() / (decimal)numbers.Where(x => x != null).Count();
                            newData.values = numbers.Select(x => (x == null) ? average : (decimal)x).ToArray();
                        }
                    }
                }
                var results = data.GroupBy(x => x.name.Substring(0, 1))
                    .Select(x => new
                    {
                        group = x.Key,
                        average = x.Average(y => y.getSumWeight)
                    }).ToList();
              
     
            }
        }
        public class Data
        {
            public static decimal[] weights = { 0.25M, 0.2M, 0.50M, 0.05M };
            public string name { get; set; }
            public decimal[] values { get; set; }
            public decimal getSumWeight { get { return values.Select((x, i) => weights[i] * x).Sum(); } }
        }
    }
