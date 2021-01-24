    var result = productsList
                    .GroupBy(l => l.Article.Title)
                    .Select(cl => new ProductItem
                    {
                        Product = cl.First(),
                        TotalAmount = cl.Sum(c => c.TotalAmount),
                    }).ToList();
