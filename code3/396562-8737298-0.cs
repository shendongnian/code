    using System;
    using System.Collections.Generic;
    
    namespace TestConsoleApplication
    {
        public interface ITrendingItem
        {
            string ItemName { get; set; }
        }
    
        public interface ITrendingCafe : ITrendingItem
        {
            string CafeName { get; set; }
        }
    
    
        public class TrendingItem<T> where T : ITrendingItem
        {
            public T trendItem { get; set; }
        }
    
        public class Cafe : ITrendingCafe
        {
            public string ItemName { get; set; }
            public string CafeName { get; set; }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                var test = new List<TrendingItem<ITrendingItem>> { new TrendingItem<ITrendingItem> { trendItem = new Cafe() } };
    
                foreach (var trendingItem in test[0].trendItem.GetType().GetInterfaces())
                {
                    Console.Out.WriteLine(trendingItem.Name);
                }
                Console.ReadKey();
            }
        }
    }
