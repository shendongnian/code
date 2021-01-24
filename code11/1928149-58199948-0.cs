        List<Product> list1 = new List<Product>() { new Product(1), new Product(3), new Product(2), new Product(6), new Product(5)};
        		List<Product> list2 = new List<Product>() { new Product(14), new Product(10), new Product(8), new Product(6), new Product(1) };
        		List<Product> list3 = new List<Product>() { new Product(11), new Product(22), new Product(38), new Product(14), new Product(155) }; //just some dummy data
        		List<List<Product>> products = new List<List<Product>>() { list1, list2, list3 };
        		
    var result = products
            			.Select(lp => lp.FirstOrDefault(x => x.Cost==lp.Max(p=>p.Cost)))
    .ToList();
