    try
    {
        var products = (from p in repository.Products
                        select new { p.Product, p.ProductName }).ToList();
        Console.WriteLine(products.FirstOrDefault().ProductName);
    }
    catch (Exception e)
    {  
        return;
    }
