    List<Product> distinctProducts = new List<Product>();
    HashSet<string> dupSet = new HashSet<string>();
    foreach (Product p in Product)
    {
        if (dupSet.ContainsKey(p.Cat1))
        {
             // do not add
        }
        else
        {
             dupSet.Add(p.Cat1);
             distinctProducts.Add(p);
        }
    }
