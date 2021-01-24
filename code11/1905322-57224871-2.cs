        public int SaveBasket(Addition addition)
        {
            var baskets = ApplicationDbContext.Basket.Where(b => b.AdditionId == addition.AdditionId);
            
            //Remove Basket
            ApplicationDbContext.Basket.RemoveRange(baskets);
            ApplicationDbContext.SaveChanges();
            ApplicationDbContext.Basket.AddRange(addition.Basket);
            return ApplicationDbContext.SaveChanges();
        }
