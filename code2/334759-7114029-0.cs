           // Declare the namespace
           XNamespace ns = "http://api.trademe.co.nz/v1";
           listBox1.ItemsSource = from TM in r.Root.Descendants(ns+"List")
                                   select new TradeItem
                                   {                                       
                                       ImageSource = TM.Element(ns+"Listing")
                                       .Element(ns+"PictureHref").Value,
                                        Message = TM.Element(ns+"PageSize").Value,
                                       UserName = TM.Element(ns+"SearchResults").Element(ns+"Page").Value
                                   }; 
