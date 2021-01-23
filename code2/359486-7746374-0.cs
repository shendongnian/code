    public static SomeEntity GetEntity(int id)
    {
        using (var db = new SomeDbContext())
        {
            return db.SomeEntities.FirstOrDefault(x => x.Id == id);
        }
    }
