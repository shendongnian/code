    IEnumerable<ProductBuyViewModel> productBuyList = dsData.Tables[0].AsEnumerable().Select(p =>
                     new ProductBuyViewModel()
                     {
                          ProductBuy = {ProductName = p["productName "],ProductPrice =p["ProductPrice ...]},
                          ProductVesrion =p["ProductVesrion "],
                          User         = {UserName =...}
                     });
