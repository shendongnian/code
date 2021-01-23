    var query = myDB.Where(p => p.field == "filter");
    
    string sort = "productID, productName";
    
    string[] sortItems = sort.Split(new string[] {", "}, StringSplitOptions.None);
    switch (sortItems[0]) {
      case "productId": query = query.OrderBy(x => x.ProductId); break;
      case "productName": query = query.OrderBy(x => x.ProductName); break;
    }
    for (int i = 1; i < sortItems.Length; i++) {
      switch (sortItems[i]) {
        case "productId": query = query.ThenBy(x => x.ProductId); break;
        case "productName": query = query.ThenBy(x => x.ProductName); break;
      }
    }
    query = query.Skip(10).Take(10);
