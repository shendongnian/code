    public decimal GetPlayerRating(int id)
    {
        return db.Ratings.Where(r=>r.PlayerID == id).Select(r=>r.Points).Sum() ?? 0;
    
    }
   
