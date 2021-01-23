	var listing = 
	xDoc.Elements("Listings")
	.Elements("Listing")
	.GroupBy (x => new { 
					ID = x.Element(XName.Get("CatID")).Value
					, Description = x.Element(XName.Get("CatDesc")).Value
				}
	)
	.Select (x => new Category { 
					ID = x.Key.ID
					, Description = x.Key.Description
					, Items = x.Select (i => new Item { 
										ID = i.Element("ItemID").Value
										, Description = i.Element("ItemDesc").Value
										, TotalPrice = decimal.Parse(i.Element("TotalPrice").Value) 
									   }
						).ToList()
				}
			)
	.OrderBy (x => x.ID);
