        ProductStatus status = ProductStatus.ForSale;
        ProductStatus nextStatus = status + 1;
        var statusChangesList = new List<KeyValuePair<Product, Status>>();
        foreach (var product in products)
        {
            statusChangesList.Add(new KeyValuePair<Product, Status>(product, product.Status));
            product.Status = nextStatus;
        }
        foreach (var statusChange in statusChangesList)
        {
            Console.WriteLine("Product: " + statusChange.key + " changed status from: " + statusCahnge.value);
        }
