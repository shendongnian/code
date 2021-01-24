    // GET: api/MyModel2
    public IQueryable<MyModel2> GetMyModel2()
    {
      return db.MyModel2.Include(x => x.ListOrder);
    }
