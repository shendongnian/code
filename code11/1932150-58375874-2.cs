    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Element> elements = new List<Element>() {
                    new Element() { no = 1, vendor = "a", Description =  "Nice", price = 10},
                    new Element() { no = 1, vendor = "a", Description =  "Nice", price = 20}
                };
                var groups = elements.GroupBy(x => x.no).ToList();
                List<Element> totals = new List<Element>();
                foreach (var group in groups)
                {
                    Element newElement = (Element)group.FirstOrDefault().Clone();
                    newElement.price = group.Sum(x => x.price);
                    totals.Add(newElement);
                }
            }
        }
        public class Element : ICloneable 
        {
            public int no { get;set; }
            public string vendor { get;set; }
            public string Description { get;set; }
            public decimal price { get;set; }
            public object Clone()
            {
                return this;
            }
        }
    }
