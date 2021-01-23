    public void TheMethod(int accountId, string searchTerm)
    {
        var result = from item in ctx.Items
                     where item.Name.Contains(searchTerm)
                     let temp = new
                         {
                             Name = item.Name,
                             IsFavorite = item.FavoriteItems
                                 .Any(f => f.AccountId == accountId)
                         }
                     orderby temp.IsFavorite descending, temp.Name
                     select temp;
    }
