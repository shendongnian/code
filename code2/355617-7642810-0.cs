        var query = (from product in Products
                    from smallPack in product.ItemPacks
                    select new
                    {
                        ItemCode = smallPack.ItemCode,
                        Item = smallPack.Item,
                        Quantity = smallPack.Quantity * product.Quantity,
                    })
                    .GroupBy(p => p.ItemCode)
                    .Select(p => new
                    {
                        ItemCode = p.Key,
                        Item = p.FirstOrDefault(),
                        Quantity = p.Sum(x=>x.Quantity)
                    })
                    .ToDictionary(p=>p.ItemCode);
