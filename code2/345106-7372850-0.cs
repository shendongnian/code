    var query = tsgdbcontext.Products
                            .GroupBy(p => new {
                                p.ProductId,
                                p.ProductName,
                                p.ProductPrice
                             })
                            .Select(g => new {
                                g.Key.ProductId,
                                g.Key.ProductName,
                                g.Key.ProductPrice,
                                Available = g.Count()
                            });
