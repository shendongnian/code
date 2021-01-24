       class Program
        {
            static void Main(string[] args)
            {
                List<Element> elements = new List<Element>() {
                    new Element() { no = 1, vendor = "a", Description =  "Nice", price = 10},
                    new Element() { no = 1, vendor = "a", Description =  "Nice", price = 20}
                };
                List<Element> totals = elements.GroupBy(x => x.no).Select(x => new Element()
                {
                    no = x.Key,
                    vendor = x.FirstOrDefault().vendor,
                    Description = x.FirstOrDefault().Description,
                    price = x.Sum(y => y.price)
                }).ToList();
     
            }
        }
        public class Element
        {
            public int no { get;set; }
            public string vendor { get;set; }
            public string Description { get;set; }
            public decimal price { get;set; }
        }
