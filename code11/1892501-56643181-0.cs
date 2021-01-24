    Contracts.Models.ProductNameResponse product = new  Contracts.Models.ProductNameResponse();
    foreach (var item in res)
        {
            product.ProductName.Add(item.Key.ProductName);
        }
