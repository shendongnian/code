    //Step 1 - Join 3 lists
    var query = (from p in products
                    join b in brands on p.BrandId equals b.Id
                    join c in categories on p.CategoryId equals c.Id
                    select new
                    {
                        b.BrandName,
                        c.CategoryName,
                        p.ProductName
                    }).ToList();
    
    //Step 2 - query required results
    var results = query
                    .GroupBy(x => new { x.BrandName, x.CategoryName })
                    .Select(x => new
                    {
                        Brand = x.Key.BrandName,
                        Category = x.Key.CategoryName,
                        Product = x.Select(y=>y.ProductName).ToList()
                    });
    
    Console.WriteLine(JsonConvert.SerializeObject(results));
