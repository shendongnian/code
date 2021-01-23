    using System.Xml.Linq;
    
    public class BillingItems
    {
        public static List<BillingItem> GetBillingItems()
    	{
    		var doc = XDocument.Load("BillingItems.xml");
    		var items = (from i in doc.Element("root").Elements("item")
                        select new BillingItem { Description = i.Element("name").Value } )
                        .ToList();
            return items;
    	}
    }
