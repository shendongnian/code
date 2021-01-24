    var ans = from i in itemList
              group i by i.ProductId into ig
              let PartNumber = ig.First().PartNumber
              select new {
                  ProductId = ig.Key,
                  PartNumber,
                  TotalOrders = ig.Sum(i => i.TotalOrders),
                  TotalSold = ig.Sum(i => i.TotalSold),
                  MarketPlaceList = (from m in ig.SelectMany(i => i.MarketPlaceList)
                                     group m by m.SiteName into mg
                                     select new {
                                         SiteName = mg.Key,
                                         SiteTotalOrders = mg.Sum(m => m.SiteTotalOrders),
                                         SiteTotalQuantity = mg.Sum(m => m.SiteTotalQuantity)
                                     }).ToList()
              };
