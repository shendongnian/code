    using (MiscEntities ctx = new MiscEntities())
    {
        try
        {
            var m = ctx.Rates.FirstOrDefault(m => m.UserId == UserIdGuid);
            DataAccess.Rate oldDbRate = new DataAccess.Rate { RatingId = m.RatingId };
            ctx.AttachTo("Rates", dbRate);
            dbRate.Rating = Rating;
            dbRate.DateLastModified = DateTime.Now;
            ctx.SaveChanges();
        }
        catch (OptimisticConcurrencyException)
        {
            ctx.Refresh(RefreshMode.ClientWins, dbRate);
            ctx.SaveChanges();
        }                
    }
 
