    public int SaveBasket(Addition addition)
    {
        var dbAddition = ApplicationDbContext.Additions
            .Include(x => x.Basket)
            .SingleOrDefault(x => x.AdditionId == addition.AdditionId);
        dbAddition.RemoveRange(dbAddition.Basket);
        dbAddition.AddRange(addition.Basket);
        return ApplicationDbContext.SaveChanges();
    }
