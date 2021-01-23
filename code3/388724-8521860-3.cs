    public void Update(game item) {
        Entities1 DB = CreateDataContext();
        var obj = (from u in DB.games
                   where u.idgames == item.idgames
                   select u).SingleOrDefault();
        if (obj == null) {
          // handle the case where obj isn't found
          // probably by throwing an exception
        }
        obj.modified = DateTime.Now;
        DB.games.ApplyCurrentValues(obj);
        DB.SaveChanges(); 
    }
