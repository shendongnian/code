    private void ChangeStatus(Product[] products)
    {
        foreach (var p in products)
        {
            p.Status = p.Status + 1;
        }
    }
