    public void Update(game item)
    {
        Entities1 DB = CreateDataContext();
        item.modified = DateTime.Now;
        var obj = (from u in DB.games
                   where u.idgames == item.idgames
                   select u).First();
        DB.games.ApplyCurrentValues(item);//Error Here
        DB.SaveChanges();         
    }
