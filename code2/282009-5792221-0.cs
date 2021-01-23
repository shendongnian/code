    // You can construct this with an array if it isn't already in this form.
    IEnumerable<IEnumerable<ResortSupplier>> supplierLists = ...
    var query = from suppliers in supplierLists
                from supplier in suppliers
                group supplier by supplier.SupplierCode into g
    
                let products = g.SelectMany(s => s.ResortProducts)
                                .GroupBy(p => p.Code)
                                .Select(prodGroup => new Product
                                        {
                                           Code = prodGroup.Key,
                                           PricingDetail = prodGroup
                                                           .SelectMany(p => p.PricingDetail)
                                                           .ToList()
                                        })
                select new ResortSupplier
                {
                    SupplierCode  = g.Key, 
                    ResortProducts = products.ToList()                              
                };
                 
