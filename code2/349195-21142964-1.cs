    /// <summary>
    /// Method that will remove a favorite from the tblfavorite table.
    /// </summary>
    /// <param name="favoriteID"></param>
    /// <returns></returns>
    public Boolean DeleteFavoriteByFavoriteID(Int32 favoriteID)
    {
        //Assume not found.
        IsFound = false;
        //Query the DB.
        var MatchedRec = (from f in dbContext.tblfavorites
                          where f.FavoriteID == favoriteID
                          select f).FirstOrDefault();
        //See if anything was found.
        if (MatchedRec != null)
        {
            IsFound = true;
            dbContext.tblfavorites.Remove(MatchedRec);
            dbContext.SaveChanges();
            return true;
        }
        //Default.
        return false;
    }
