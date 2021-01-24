    var result = productsList
                .GroupBy(l => l.Article.Title)
                .Select(cl => 
                {
                        var product = new Product();
                        Reflection.CopyProperties(cl.First(), product);
                        product.TotalAmount = cl.Sum(c => c.TotalAmount);
                        return product;
                }).ToList();
