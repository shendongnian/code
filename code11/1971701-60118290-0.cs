    var consumer = Task.Run(() =>
    {
        var batch = new List<Product>();
        foreach (Product readyProduct in productsQueue.GetConsumingEnumerable())
        {
            batch.Add(readyProduct);
            if (batch.Count >= 100)
            {
                context.Products.AddRange(batch);
                context.SaveChanges();
                foreach (var p in batch)
                {
                    context.Entry(p).State = EntityState.Detached;
                }
                batch.Clear();
            }
            
        }
        context.Products.AddRange(batch);
        context.SaveChanges();
        foreach (var p in batch)
        {
            context.Entry(p).State = EntityState.Detached;
        }
    });
