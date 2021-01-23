    IEnumerable<IGrouping<int, Product>> groups = store1
       .Concat(store2)
       .Concat(store3)
       .GroupBy(prod => prod.Id);
    List<Product> allProducts = groups
      .Select(g => g.First())
      .ToList();
    List<Product> moreThanOneStoreProducts = groups
      .Where(g => g.Skip(1).Any())
      .Select(g => g.First())
      .ToList();
