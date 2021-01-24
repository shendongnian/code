    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace so
    {
        class Program
        {
            static void Main(string[] args)
            {
                var data = new List<Item>
                {
                    new Item {CN8 = 123456789, goodsDescription = "blah0", MSConsDestCode = "DE", countryOfOriginCode = "CN", netMass = 1  },
                    new Item {CN8 = 123456789, goodsDescription = "blah1", MSConsDestCode = "DE", countryOfOriginCode = "CN", netMass = 1  },
                    new Item {CN8 = 123456789, goodsDescription = "blah2", MSConsDestCode = "GB", countryOfOriginCode = "IN", netMass = 1  }
                };
                // Here is your query
                var groupedData = data.GroupBy(di => new {di.CN8, di.MSConsDestCode, di.countryOfOriginCode}).Select(group => new Item{ netMass = group.Sum(gi => gi.netMass),goodsDescription = group.First().goodsDescription, CN8=group.Key.CN8, MSConsDestCode=group.Key.MSConsDestCode, countryOfOriginCode=group.Key.countryOfOriginCode} );
            }
        }
    
        public class Item
        {
            public int CN8 { get; internal set; }
            public string goodsDescription { get; internal set; }
            public string MSConsDestCode { get; internal set; }
            public string countryOfOriginCode { get; internal set; }
            public decimal netMass { get; internal set; }
        }
    }
