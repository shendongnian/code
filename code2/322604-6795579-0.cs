    var groups = from x in xd.Element("Menu").Elements("MenuItem")
    	         select new
    	         {
                     Items = (from c in x.Elements("MenuContent")
                              select new
                              {
                                  Description = c.Element("Description").Value,
                                  ImageToolTip = c.Element("ImageToolTip").Value,
                                  ImageUrl = c.Element("ImageUrl").Value,
                                  LinkUrl = c.Element("LinkUrl").Value,
                                  Title = c.Element("Title").Value
                              }).ToList()
                 };
