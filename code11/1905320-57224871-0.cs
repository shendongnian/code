        public int SaveBasket(Addition addition)
        {
            var entity = ApplicationDbContext.Additions.Find(addition.AdditionId); // Find by primary key
    
            //Remove Basket
            if (entity.Basket.Count > 0)
            {
                entity.Basket.Clear(); // Empty out the basket
    
                ApplicationDbContext.SaveChanges();
            }
    
            //Add new basket entities from posting json data
            addition.Basket.ForEach(b => entity.Basket.Add(b)); // Add the items
    
            return ApplicationDbContext.SaveChanges();
        }
