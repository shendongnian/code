    private void ChangeStatus(ProductStatus initialStatus, Product[] products)
    {
        ProductStatus nextStatus = initialStatus + 1;
        foreach (var p in products)
        {
            p.Status = nextStatus;
        }
    }
    private void ShowProducts(Product[] products)
    {
        foreach (var p in products)
        {
            Console.WriteLine("{0}: " + p.ToString(), status.ToString());
        }
    }
