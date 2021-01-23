    public void Linq42()
    {
        List<Prod> products = GetProductList();
     
        var serialCombined =
            from p in products
            group p by p.SerialNumber into g
            select new { SerialNumber = g.Key, Total = g.Count() };
    }
