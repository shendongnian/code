    using System.Xml.Linq;
        
    public class BillingItems : List<BillingItem>
    {
        // Constructor.
        private BillingItems(List<BillingItem> items) : base(items) { }
    
        public static BillingItems GetBillingItems()
        {
            var doc = XDocument.Load("BillingItems.xml");
            var items = (from i in doc.Element("root").Elements("item")
                            select new BillingItem { Description = i.Element("name").Value })
                        .ToList();
            return new BillingItems(items);
        }
    }
