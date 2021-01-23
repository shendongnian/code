    if(User.IsAuthenticated)
    {
        var q = from item in db.Item
                join r in db.Rating on c.Id equals r.ItemId
                select new {ID = item.Id, Contents = item.Contents, Rating = r.Rating};
        // Do whatever you want with this here.
    }
    else
    {
        var y = db.Item;
        // Do whatever you want with this here.
    }
