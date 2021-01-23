    XDocument xDoc = XDocument.Parse(XmlizedString);
    
    var listing = from x in xDoc.Elements("Listings").Elements("Listing")
                  orderby (string)x.Element("CatID")
                  select new Category {
                      ID = x.CatID, 
                      Description = x.CatDesc, 
                      Items = new Item { 
                          x.ItemID,  
                          Description = x.ItemDesc, 
                          TotalPrice = x.TotalPrice 
                      } 
                  };
