    public int SaveBasket(Addition addition)
    {
        var dbAddition = ApplicationDbContext.Additions
            .Include(x => x.Basket)
            .SingleOrDefault(x => x.AdditionId == addition.AdditionId);
        ApplicationDbContext.Basket.RemoveRange(dbAddition.Basket);
        ApplicationDbContext.Basket.AddRange(addition.Basket);
        return ApplicationDbContext.SaveChanges();
    }
