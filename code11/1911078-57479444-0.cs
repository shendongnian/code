    var data = new List<Item>
	{
	  new Item {CN8 = 123456789, goodsDescription = "blah0", MSConsDestCode = "DE", countryOfOriginCode = "CN", netMass = 1  },
	  new Item {CN8 = 123456789, goodsDescription = "blah1", MSConsDestCode = "DE", countryOfOriginCode = "CN", netMass = 1  },
	  new Item {CN8 = 123456789, goodsDescription = "blah2", MSConsDestCode = "GB", countryOfOriginCode = "IN", netMass = 1  }
	};
		
	var combined = data.GroupBy(x => new {x.CN8, x.MSConsDestCode, x.countryOfOriginCode})
	                   .Select(x => new Item
                         {
                           CN8 = x.Key.CN8,
                           goodsDescription = x.First().goodsDescription,
                           MSConsDestCode = x.Key.MSConsDestCode,
                           countryOfOriginCode = x.Key.countryOfOriginCode,
                           netMass = x.Sum(v => v.netMass)
                         });
		
