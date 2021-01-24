    sing System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                Stocks stocks = new Stocks();
                IEnumerable<DateLowHigh> csvData = stocks.candles.Select(c => new DateLowHigh
                {
                    Time = c.datetime,
                    Close = c.close,
                    Low = c.low,
                    High = c.high
                }).ToList();
                MemoryStream memoryStream = new MemoryStream();
                using (var writer = new StreamWriter(memoryStream))
                {
                    string[] headers = {"Time", "Close", "Low", "High"};
                    writer.WriteLine(string.Join(",", headers));
                    foreach (var item in csvData)
                    {
                        writer.WriteLine(string.Join(",", new string[] { item.Time.ToString(), item.Close, item.Low.ToString(), item.High.ToString() }));
                    }  
                }
                memoryStream.Position = 0;
            }
        }
        public class Stocks
        {
            public List<Candle> candles { get; set; }
        }
        public class Candle
        {
            public DateTime datetime { get; set; }
            public string close { get; set; }        
            public int low { get; set; }
            public int high { get; set; }
        }
        public class DateLowHigh
        {
            public DateTime Time { get; set; }
            public string Close { get; set; }
            public int Low { get; set; }
            public int High { get; set; }
        }
    }
